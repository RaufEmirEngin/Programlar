import math

def calculate_difference(x, real_value):
    # e^x
    e_to_x = math.exp(x)
    # e^-x
    e_to_minus_x = math.exp(-x)

    # seri açılımı için gerekli değişkenlerin tanımlanması
    sum_result = 0
    term = 1
    n = 0

    # seri açılımının hesaplanması
    while True:
        sum_result += term
        n += 1
        term *= x**2 / (2*n-1) / (2*n)
        if abs(term) < 1e-9:
            break

    # gerçek değer ile hesaplanan değerin karşılaştırılması
    difference = abs(real_value - (e_to_x - e_to_minus_x) / 2 / x)
    percent_difference = difference / real_value * 100

    # sonuçların ekrana yazdırılması
    print(f"Seri açılımı sonucu: {sum_result}")
    print(f"Gerçek değer: {real_value}")
    print(f"Fark: %{percent_difference:.2f}")

while True:
    x = float(input("x değerini girin: "))
    real_value = float(input("Gerçek değeri girin: "))

    calculate_difference(x, real_value)

    answer = input("Tekrar denemek istiyor musunuz? (E/H): ")
    if answer.lower() != "e":
        print("Seri Açılımı")
        break
