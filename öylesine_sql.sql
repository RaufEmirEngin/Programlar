
-- tablo olustur
CREATE TABLE ogretmen (
  no INTEGER PRIMARY KEY,
  isim TEXT NOT NULL,
  cinsiyet TEXT NOT NULL,
  maas INTEGER NOT NULL
);
-- deger girin
INSERT INTO ogretmen VALUES (1, 'Ahmet', 'E', '5500');
INSERT INTO ogretmen VALUES (2, 'Elif', 'K', '7000');
INSERT INTO ogretmen VALUES (3, 'Arif', 'E', '4800');
INSERT INTO ogretmen VALUES (4, 'Mehmet', 'E', '5000');
INSERT INTO ogretmen VALUES (5, 'Sultan', 'K', '6000');

-- ogretmen tablosundaki cinsiyeti erkek olan şahıslar
SELECT * FROM ogretmen WHERE cinsiyet = 'E';

CREATE TABLE duzen (
  tire varchar(50) NOT NULL
);
INSERT INTO duzen VALUES ('----------------------------------------------');

SELECT tire FROM duzen;
SELECT * FROM ogretmen ORDER BY maas;
SELECT tire FROM duzen;

-- ogretmen tablosundaki kadın öğretmenlerin isimleri ve yıllık maaşları
SELECT isim, 12 * maas AS yillik_maas FROM ogretmen WHERE cinsiyet = 'K';

SELECT tire FROM duzen;

-- tablo olustur
CREATE TABLE ogrenci (
  ogrencino INTEGER PRIMARY KEY,
  isim TEXT NOT NULL,
  soyisim TEXT NOT NULL,
  cinsiyet TEXT NOT NULL,
  ortalama INTEGER NOT NULL,
  yas INTEGER NOT NULL,
  sehir TEXT NOT NULL
);
-- deger girin  
INSERT INTO ogrenci VALUES (1, 'Berkay', 'Erikli', 'E', 85, 20, 'Antalya');
INSERT INTO ogrenci VALUES (2, 'Beyza', 'Aydın', 'K', 68, 19, 'İzmir');
INSERT INTO ogrenci VALUES (3, 'Emir', 'Seven', 'E', 95, 21, 'İstanbul');
INSERT INTO ogrenci VALUES (4, 'Selim', 'Sayın', 'E', 70, 20, 'İzmir');
INSERT INTO ogrenci VALUES (5, 'Fatma', 'Kılıç', 'K', 72, 18, 'Antalya');

SELECT isim FROM ogrenci WHERE ortalama BETWEEN 70 AND 90;
SELECT tire FROM duzen;

SELECT ogrencino FROM ogrenci WHERE sehir = 'Antalya'; 
SELECT tire FROM duzen;

SELECT isim, yas FROM ogrenci WHERE isim LIKE 'B%';
SELECT tire FROM duzen;

SELECT isim FROM ogrenci WHERE yas = 20 AND sehir = 'Antalya';
SELECT tire FROM duzen;

SELECT isim, ortalama FROM ogrenci WHERE cinsiyet = 'K' OR sehir = 'İstanbul';
SELECT tire FROM duzen;

SELECT * FROM ogrenci WHERE ortalama != 100;
SELECT tire FROM duzen;

-- calisan tablosu
CREATE TABLE Calisanlar (
  isci_no INTEGER PRIMARY KEY,
  isim TEXT NOT NULL,
  soyisim TEXT NOT NULL,
  bolum_no INTEGER 
);
INSERT INTO Calisanlar VALUES (1, 'Kadir', 'Yıldırım', 1);
INSERT INTO Calisanlar VALUES (2, 'Fatmanur', 'Kaplan', 2);
INSERT INTO Calisanlar VALUES (3, 'Mert', 'Topaloglu', 1);
INSERT INTO Calisanlar VALUES (4, 'Ayse', 'Yılmaz', NULL);

-- bolum tablosu
CREATE TABLE Bolum (
  bolum_no INTEGER,
  bolum_adi TEXT
);
INSERT INTO Bolum VALUES (1, 'Bilgisayar');
INSERT INTO Bolum VALUES (2, 'Cevre');
INSERT INTO Bolum VALUES (3, 'Gida');

-- beceri tablosu 
CREATE TABLE Beceriler (
  isci_no INTEGER,
  bildigi_diller TEXT NOT NULL
);
INSERT INTO Beceriler VALUES (1, 'C++');
INSERT INTO Beceriler VALUES (1, 'Java');
INSERT INTO Beceriler VALUES (1, 'Basic');
INSERT INTO Beceriler VALUES (2, 'PhP');
INSERT INTO Beceriler VALUES (2, 'Oracle');
INSERT INTO Beceriler VALUES (3, 'Java');
INSERT INTO Beceriler VALUES (3, 'Oracle');

SELECT c.isci_no, c.isim, c.soyisim, b.bolum_adi
FROM Calisanlar c
JOIN Bolum b ON c.bolum_no = b.bolum_no;

SELECT c.isci_no, c.isim, b.bildigi_diller
FROM Calisanlar c
JOIN Beceriler b ON c.isci_no = b.isci_no;

SELECT LOWER(isim) AS adi FROM Calisanlar WHERE bolum_no = 1;
SELECT UPPER(isim) AS adi FROM Calisanlar WHERE isci_no < 3;

-- amele tablosu
CREATE TABLE amele (
  no INTEGER PRIMARY KEY,
  adi TEXT NOT NULL,
  saat_ucreti FLOAT NOT NULL
);
INSERT INTO amele VALUES (1, 'Ahmet', 55.49);
INSERT INTO amele VALUES (2, 'Emre', 70.87);
INSERT INTO amele VALUES (3, 'Arif', 48.12);
INSERT INTO amele VALUES (4, 'Mehmet', 50.45);
INSERT INTO amele VALUES (5, 'Semih', 60.00);

SELECT adi, saat_ucreti AS gunluk, ROUND(saat_ucreti * 8, 2) AS yevmiye FROM amele;
SELECT AVG(saat_ucreti) AS ortalama FROM amele;
SELECT SUM(saat_ucreti) AS toplam FROM amele;

-- hayvan tablosu
CREATE TABLE hayvan (
  ayak_sayisi INTEGER NOT NULL,
  id TEXT NOT NULL,
  yasam_alani TEXT NOT NULL,
  boy_cm INTEGER NOT NULL
);
INSERT INTO hayvan VALUES (2, 'penguen', 'kara', 60);
INSERT INTO hayvan VALUES (4, 'aslan', 'kara', 80);
INSERT INTO hayvan VALUES (0, 'balina', 'su', 3000);
INSERT INTO hayvan VALUES (2, 'sahin', 'hava', 50);
INSERT INTO hayvan VALUES (2, 'at', 'kara', 200);

SELECT COUNT(*) AS hayvanlar FROM hayvan WHERE boy_cm > 20;
SELECT yasam_alani FROM hayvan GROUP BY yasam_alani;

--  UPDATE öğretmen maaşı
UPDATE ogretmen SET maas = 7500 WHERE isim = 'Ahmet';

--  DELETE öğrenci
DELETE FROM ogrenci WHERE isim = 'Selim';

--  ALTER TABLE - Amele tablosuna 'meslek' sütunu ekle
ALTER TABLE amele ADD COLUMN meslek TEXT DEFAULT 'İşçi';

--  UPDATE hayvan boyu
UPDATE hayvan SET boy_cm = 3050 WHERE id = 'balina';

--  Yeni JOIN
SELECT c.isim, b.bolum_adi
FROM Calisanlar c
LEFT JOIN Bolum b ON c.bolum_no = b.bolum_no;

-- OGRETMEN TABLOSU

-- Yeni bir öğretmen ekle
INSERT INTO ogretmen VALUES (6, 'Burcu', 'K', 8000);

-- En yüksek maaşlı öğretmeni listele
SELECT * FROM ogretmen WHERE maas = (SELECT MAX(maas) FROM ogretmen);

-- Ortalama maaşı hesapla
SELECT AVG(maas) AS ortalama_maas FROM ogretmen;


-- OGRENCI TABLOSU

-- Şehir bazında öğrenci sayısı
SELECT sehir, COUNT(*) AS ogrenci_sayisi FROM ogrenci GROUP BY sehir;

-- Ortalama notu en yüksek 2 öğrenci
SELECT isim, ortalama FROM ogrenci ORDER BY ortalama DESC LIMIT 2;

-- Öğrencilerin yaşlarına göre sıralanmış listesi
SELECT isim, yas FROM ogrenci ORDER BY yas;


-- CALISANLAR & BOLUM TABLOLARI

-- Bölüm bilgisi olmayan çalışanlara NULL yerine "Belirsiz" yaz
SELECT c.isim, COALESCE(b.bolum_adi, 'Belirsiz') AS bolum
FROM Calisanlar c
LEFT JOIN Bolum b ON c.bolum_no = b.bolum_no;

-- Her bölümde kaç çalışan var?
SELECT b.bolum_adi, COUNT(c.isci_no) AS calisan_sayisi
FROM Bolum b
LEFT JOIN Calisanlar c ON b.bolum_no = c.bolum_no
GROUP BY b.bolum_adi;


-- BECERILER TABLOSU

-- Java bilen işçileri listele
SELECT DISTINCT isci_no FROM Beceriler WHERE bildigi_diller = 'Java';

-- Her çalışanın kaç becerisi var?
SELECT isci_no, COUNT(*) AS beceri_sayisi
FROM Beceriler
GROUP BY isci_no;


-- AMELE TABLOSU

-- Saatlik ücretine göre en pahalı çalışan
SELECT * FROM amele ORDER BY saat_ucreti DESC LIMIT 1;

-- Yevmiyesi 450 TL'den fazla olanları listele
SELECT adi, ROUND(saat_ucreti * 8, 2) AS yevmiye
FROM amele
WHERE ROUND(saat_ucreti * 8, 2) > 450;

-- Meslek sütununu güncelle
UPDATE amele SET meslek = 'Kaynakçı' WHERE adi = 'Ahmet';


-- HAYVAN TABLOSU

-- Kara hayvanlarının ortalama boyu
SELECT AVG(boy_cm) AS ortalama_boy FROM hayvan WHERE yasam_alani = 'kara';

-- Hayvanlara yeni bir ID türü sütunu ekle
ALTER TABLE hayvan ADD COLUMN kategori TEXT DEFAULT 'Genel';

-- Balıkların kategorisini güncelle
UPDATE hayvan SET kategori = 'Deniz Canlısı' WHERE yasam_alani = 'su';

