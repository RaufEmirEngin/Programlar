# -*- coding: utf-8 -*-

from google.colab import drive
drive.mount('/content/drive')

import pandas as pd
import numpy as np
import tensorflow as tf
import torch

# Excel dosyasından veri setini okuma
excel_file = '/content/drive/MyDrive/PSSP.xlsx'  # Veri setinizin adı ve yolu
df = pd.read_excel(excel_file)

# CPNR değerleri
Cpnr_values = {
    'A': '37', 'R': '47', 'N': '41', 'D': '59', 'C': '11', 'Q': '29',
    'E': '61', 'G': '43', 'H': '17', 'I': '53', 'L': '23', 'K': '67',
    'M': '1', 'F': '3', 'P': '7', 'S': '31', 'T': '13', 'W': '2',
    'Y': '5', 'V': '19', '*': '0'
}

df['Seq'] = df['Seq'].astype(str)
df['Structure'] = df['Structure'].astype(str)

# Veri setindeki 'Seq' ve 'Structure' sütunlarını CPNR değerlerine dönüştürme işlevi
def convert_to_cpnr(sequence):
    return ''.join([Cpnr_values.get(aa, '0') for aa in sequence])

# 'Seq' ve 'Structure' sütunlarını CPNR değerlerine dönüştürme
df['Seq_CPNR'] = df['Seq'].apply(convert_to_cpnr)
df['Structure_CPNR'] = df['Structure'].apply(convert_to_cpnr)

"""'float' object is not iterable hatası, muhtemelen Seq ve Structure sütunlarında sayısal olmayan (float) değerler olduğunu belirtiyor.

Seq ve Structure sütunlarındaki verileri önce string olarak dönüştürdük.
"""

# CPNR değerlerini içeren DataFrame'i gösterme
print(df[['Seq', 'Seq_CPNR', 'Structure', 'Structure_CPNR', 'Sınıflar']])

from sklearn.model_selection import train_test_split
from sklearn.metrics import accuracy_score, f1_score, precision_score, recall_score, confusion_matrix, roc_curve, auc
import matplotlib.pyplot as plt
from keras.models import Sequential
from keras.layers import LSTM, Dense

# Girdi ve etiketlerin belirlenmesi
X = df[['Seq_CPNR', 'Structure_CPNR']]
y = df['Sınıflar']

# Veri setini train ve test olarak bölme
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# LSTM modeli oluşturma
model = Sequential()
model.add(LSTM(128, input_shape=(X_train.shape[1], 1)))
model.add(Dense(1, activation='sigmoid'))

model.compile(loss='binary_crossentropy', optimizer='adam', metrics=['accuracy'])

# Veri setinin boyutunu yeniden şekillendirme
X_train = X_train.values.reshape((X_train.shape[0], X_train.shape[1], 1))
X_test = X_test.values.reshape((X_test.shape[0], X_test.shape[1], 1))

print("X_train shape:", X_train.shape)
print("X_test shape:", X_test.shape)
print("y_train shape:", y_train.shape)
print("y_test shape:", y_test.shape)

print(df.dtypes)

X_train = tf.convert_to_tensor(X_train, dtype=tf.float32)
y_train = tf.convert_to_tensor(y_train, dtype=tf.float64)
X_test = tf.convert_to_tensor(X_test, dtype=tf.float32)
y_test = tf.convert_to_tensor(y_test, dtype=tf.float32)

from sklearn.preprocessing import LabelEncoder

label_encoder = LabelEncoder()
y_train = label_encoder.fit_transform(y_train)
y_test = label_encoder.transform(y_test)

# Modeli eğitme
model.fit(X_train, y_train, epochs=10, batch_size=32)

# Sınıflandırma sonuçlarını tahmin etme
y_pred_prob = model.predict(X_test)  # Olasılık değerlerini elde etme
# Olasılık değerlerini sınıf etiketlerine dönüştürme
y_pred = np.argmax(y_pred_prob, axis=1)

accuracy = accuracy_score(y_test, y_pred)
f1 = f1_score(y_test, y_pred, average='weighted') # veya 'micro', 'macro' gibi bir average değeri seçebilirsiniz
precision = precision_score(y_test, y_pred, average='weighted')
recall = recall_score(y_test, y_pred, average='weighted')
conf_matrix = confusion_matrix(y_test, y_pred)

# Karmaşıklık matrisini gösterme
print("Confusion Matrix:")
print(conf_matrix)

from sklearn.metrics import roc_auc_score,roc_curve

y_true = np.array([0, 0, 0, 0])
y_scores = np.array([1, 0, 0, 0])

try:
 fpr, tpr, thresholds = roc_curve(y_true, y_scores)
except ValueError:
    pass

fpr, tpr, thresholds = roc_curve(y_true, y_scores)

plt.figure()
plt.plot([0, 1], [0, 1], color='navy', lw=2, linestyle='--')
plt.xlabel('False Positive Rate')
plt.ylabel('True Positive Rate')
plt.title('Receiver Operating Characteristic (ROC) Curve')
plt.legend(loc="lower right")
plt.show()