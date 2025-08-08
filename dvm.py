# -*- coding: utf-8 -*-

import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split
from sklearn.metrics import classification_report, confusion_matrix
from sklearn.preprocessing import LabelEncoder
from sklearn.ensemble import RandomForestClassifier
from sklearn.metrics import roc_auc_score
from sklearn.feature_selection import SelectKBest, chi2

# Veri seti oku ve işle
data = pd.read_excel('/content/drive/MyDrive/PSSP.xlsx')

# Veri seti özetle
print(data.describe())

# Sayısallaştırma
for col in data.columns:
    if data[col].dtype == 'object':
        labelencoder = LabelEncoder()
        data[col] = labelencoder.fit_transform(data[col])

# Sınıflandırma değişkeni oluştur
data['Class'] = data['Seq'].apply(lambda x: 1 if x == 1 else 0)

# X ve y oluştur
X = data.drop('Class', axis=1)
y = data['Class']

# Sınıflandırma ve doğruluk için veri setini böl
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=1)

from sklearn.feature_selection import SelectKBest, chi2

# SelectKBest with chi2 score function
chi2 = SelectKBest(score_func=chi2, k=4) # 4 en önemli öznitelik seçilir
X_train_chi2 = chi2.fit_transform(X_train, y_train)

from sklearn.feature_selection import SelectKBest, chi2

# SelectKBest with chi2 score function
chi2 = SelectKBest(score_func=chi2, k='all') # tüm öznitelikler seçilir
X_train_chi2 = chi2.fit_transform(X_train, y_train)

X_test_chi2 = chi2.transform(X_test)

# Random Forest Sınıflandırıcısı
rf = RandomForestClassifier(n_estimators=100, random_state=1)
rf.fit(X_train_chi2, y_train)

y_pred = rf.predict(X_test_chi2)

# Öngörü yap ve performans ölçümü
y_pred = rf.predict(chi2.transform(X_test))

print('Confusion Matrix')
print(confusion_matrix(y_test, y_pred))

print('Classification Report')
print(classification_report(y_test, y_pred))

print('AUC Score')
print(roc_auc_score(y_test, y_pred))

# Karmaşıklık matrisi
importances = rf.feature_importances_
indices = np.argsort(importances)

print('Feature Importances')
for f in range(X.shape[1]):
    print("%2d) %-*s %f" % (f + 1, 30, X.columns[indices[f]], importances[indices[f]]))