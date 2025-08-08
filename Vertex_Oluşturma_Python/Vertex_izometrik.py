
import matplotlib.pyplot as plt
import numpy as np
from mpl_toolkits.mplot3d import Axes3D

# Küp noktalarını tanımla
vertices = [(-1, 1, 1), (1, 1, 1), (1, -1, 1), (-1, -1, 1), (-1, 1, -1), (1, 1, -1), (1, -1, -1), (-1, -1, -1)]

# Küp yüzeylerini tanımla
faces = [[0, 1, 2, 3], [4,5,6,7], [0,4,5,1], [1,5,6,2], [2,6,7,3], [4,0,3,7]]

# Köşe noktalarını tanımla
corner1 = (1,1,1)
corner2 = (1,-1,1)
corner3 = (-1,-1,1)
corner4 = (-1,1,1)
corner5 = (1,1,-1)
corner6 = (1,-1,-1)
corner7 = (-1,-1,-1)
corner8 = (-1,1,-1)

# Orta noktaların koordinatlarını hesapla
x1 = (corner1[0] + corner2[0] + corner3[0]) / 3
y1 = (corner1[1] + corner2[1] + corner3[1]) / 3
z1 = (corner1[2] + corner2[2] + corner3[2]) / 3

x2 = (corner1[0] + corner4[0] + corner8[0]) / 3
y2 = (corner1[1] + corner4[1] + corner8[1]) / 3
z2 = (corner1[2] + corner4[2] + corner8[2]) / 3

x3 = (corner1[0] + corner5[0] + corner6[0]) / 3
y3 = (corner1[1] + corner5[1] + corner6[1]) / 3
z3 = (corner1[2] + corner5[2] + corner6[2]) / 3

# Küpün kesilmiş köşesi noktalarını tanımla
cut_vertices = [(x1, y1, z1), (x2, y2, z2), (x3, y3, z3)]

# 3D grafik oluştur
fig = plt.figure()
ax = fig.add_subplot(111, projection = '3d')

# Küp yüzeylerini çiz
for face in faces:
    x = [vertices[vertex] [0] for vertex in face]
    y = [vertices[vertex] [1] for vertex in face]
    z = [vertices[vertex] [2] for vertex in face]
    ax.plot_trisurf(x, y, z, alpha=0.5)

# Eksenleri göster
plt.show()