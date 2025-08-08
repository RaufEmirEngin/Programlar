// Rauf Emir Engin - 1190505042
// Utku Özcan - 5200505022

import java.util.ArrayList;

// Kitap sınıfı
class Kitap {
    private String kitapAdi;
    private String yazar;
    private boolean oduncAlindi;

    public Kitap(String kitapAdi, String yazar) {
        this.kitapAdi = kitapAdi;
        this.yazar = yazar;
        this.oduncAlindi = false;
    }

    public String getKitapAdi() {
        return kitapAdi;
    }

    public String getYazar() {
        return yazar;
    }

    public boolean isOduncAlindi() {
        return oduncAlindi;
    }

    public void oduncVer() {
        oduncAlindi = true;
    }

    public void iadeAl() {
        oduncAlindi = false;
    }
}

// Uye sınıfı
class Uye {
    private String adSoyad;
    private ArrayList<Kitap> oduncKitaplar;

    public Uye(String adSoyad) {
        this.adSoyad = adSoyad;
        this.oduncKitaplar = new ArrayList<>();
    }

    public String getAdSoyad() {
        return adSoyad;
    }

    public ArrayList<Kitap> getOduncKitaplar() {
        return oduncKitaplar;
    }

    public void kitapOduncAl(Kitap kitap) {
        oduncKitaplar.add(kitap);
        kitap.oduncVer();
    }

    public void kitapIadeEt(Kitap kitap) {
        oduncKitaplar.remove(kitap);
        kitap.iadeAl();
    }
}

// Gorevli sınıfı
class Gorevli {
    private String adSoyad;

    public Gorevli(String adSoyad) {
        this.adSoyad = adSoyad;
    }

    public String getAdSoyad() {
        return adSoyad;
    }

    public void kitapEkle(ArrayList<Kitap> kitapListesi, Kitap kitap) {
        kitapListesi.add(kitap);
    }

    public void kitapCikar(ArrayList<Kitap> kitapListesi, Kitap kitap) {
        kitapListesi.remove(kitap);
    }

    public void uyeEkle(ArrayList<Uye> uyeListesi, Uye uye) {
        uyeListesi.add(uye);
    }

    public void uyeCikar(ArrayList<Uye> uyeListesi, Uye uye) {
        uyeListesi.remove(uye);
    }
}

public class Main {
    public static void main(String[] args) {
        // Kitapları ve üyeleri tutacak listeler
        ArrayList<Kitap> kitapListesi = new ArrayList<>();
        ArrayList<Uye> uyeListesi = new ArrayList<>();

        // Kitap ve üye oluşturma
        Kitap kitap1 = new Kitap("Java Programming", "John Doe");
        Kitap kitap2 = new Kitap("Introduction to Algorithms", "Jane Smith");

        Uye uye1 = new Uye("Rauf Emir Engin");
        Uye uye2 = new Uye("Utku Ozcan");

        // Görevli oluşturma
        Gorevli gorevli = new Gorevli("Gorevli Gorevli");

        // Kitap ve üye ekleme
        gorevli.kitapEkle(kitapListesi, kitap1);
        gorevli.kitapEkle(kitapListesi, kitap2);

        gorevli.uyeEkle(uyeListesi, uye1);
        gorevli.uyeEkle(uyeListesi, uye2);

        // Kitap ödünç alma ve iade etme
        uye1.kitapOduncAl(kitap1);
        uye2.kitapOduncAl(kitap2);

        System.out.println("Ödünç Alınan Kitaplar - Üye 1: " + uye1.getOduncKitaplar());
        System.out.println("Ödünç Alınan Kitaplar - Üye 2: " + uye2.getOduncKitaplar());

        uye1.kitapIadeEt(kitap1);
        uye2.kitapIadeEt(kitap2);

        System.out.println("İade Edilen Kitaplar - Üye 1: " + uye1.getOduncKitaplar());
        System.out.println("İade Edilen Kitaplar - Üye 2: " + uye2.getOduncKitaplar());
    }
}
