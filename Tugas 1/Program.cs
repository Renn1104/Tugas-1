using System;

class Program
{
    static void Main(string[] args)
    {
        //Rekening rekening1 = new Rekening("232410101016","ronal",30);
        //rekening1.setorUang(40);
        //rekening1.tarikUang(20);
        //rekening1.cekSaldo();

        //Rekening rekening2 = new Rekening("234124141", "rangga", 1000);
        //rekening2.tambahkanBunga(10);
        //rekening2.cekSaldo();


        //Rekening rekening1 = new Tabungan("232401010115", "rendy", 200000);
        //rekening1.tambahkanBunga(10);
        //rekening1.cekSaldo();
        //rekening1.tarikUang(100001);
        //rekening1.cekSaldo();

        //Rekening rendy = new Giro("123131u23", "rendy", 100000);
        Bank daftarrekeningbank = new Bank();
        //ariski.tarikUang(300000);
        //ariski.cekSaldo();

        //daftarrekeningbank.TambahkanRekening(rendy);

        //daftarrekeningbank.TampilkanDaftarRekening();
        Rekening Rangga = new Rekening("12931204124", "Rangga", 100000);
        Rekening Rendy = new Tabungan("1293719486812", "Rendy", 100000);
        Rekening Ronal = new Giro("912873981274", "Ronal", 200000);

        Rendy.tarikUang(100001);
        Rendy.cekSaldo();

        Ronal.tarikUang(300001);
        Ronal.cekSaldo();
        Ronal.tambahkanBunga(20);
        Ronal.cekSaldo();


        daftarrekeningbank.TambahkanRekening(Rendy);
        daftarrekeningbank.TambahkanRekening(Ronal);
        daftarrekeningbank.TambahkanRekening(Rangga);
        daftarrekeningbank.TampilkanDaftarRekening();
    }

}

class Bank
{
    private List<Rekening> daftarRekening = new List<Rekening>();

    public void TambahkanRekening(Rekening rekening)
    {
        daftarRekening.Add(rekening);
        Console.WriteLine($"{rekening} Berhasil di tambahkan kedalam Bank");
    }

    public void TampilkanDaftarRekening()
    {
        Console.WriteLine("\nDaftar Rekening pada Bank:");
        foreach (var rekeing in daftarRekening)
        {
            rekeing.infoRekening();
        }
    }
}
class Rekening
{
    public string nomorRekening;
    public string namaNasabah;
    public double saldo;

    public Rekening(string nomorRekening, string namaNasabah, double saldo)
    {
        this.nomorRekening = nomorRekening;
        this.namaNasabah = namaNasabah;
        this.saldo = saldo;
    }

    public void setorUang(double tambahSaldo)
    {
        saldo += tambahSaldo;
    }

    public virtual void tarikUang(double jumlah)
    {
        if (saldo < jumlah)
        {
            Console.WriteLine("Saldo tidak mencukupi");
        }
        else
        {
            Console.WriteLine("Penarikan Uang Berhasil");
            saldo -= jumlah;
        }
    }

    public void cekSaldo()
    {
        Console.WriteLine($"Jumlah Saldo Anda Saat Ini : {saldo}");

    }
    public virtual void tambahkanBunga(double bunga)
    {
        Console.WriteLine("Bunga hanya diberikan pada rekening Tabungan");
    }

    public void infoRekening()
    {
        Console.WriteLine($"\nNama Nasabah :{namaNasabah} \nNomor Rekening {nomorRekening} \nJumlah Saldo {saldo}");
    }

}

class Tabungan : Rekening
{

    public Tabungan(string nomorRekening, string namaNasabah, double saldo) : base(nomorRekening, namaNasabah, saldo)
    {

    }
    public override void tambahkanBunga(double bunga)
    {
        double totalbunga = saldo * bunga / 100 * 1 / 12;
        saldo += totalbunga;
        Console.WriteLine($"Bunga Berhasil di tambahkan Kedalam saldo tabungan sebesar : {totalbunga}");
    }

    public override void tarikUang(double jumlah)
    {
        if (jumlah > saldo)
        {
            Console.WriteLine("Penarikan Gagal Karena Jumlah Saldo Tidak Mencukupi");
        }

        else if (jumlah > 100000)
        {
            Console.WriteLine("Penarikan GagaL Karena Melebihi Batas Yang Ditentukan");
        }
        else
        {
            Console.WriteLine("Penarikan Uang Berhasil");
            saldo -= jumlah;
        }
    }

}

class Giro : Rekening
{
    public Giro(string nomorRekening, string namaNasabah, double saldo) : base(nomorRekening, namaNasabah, saldo)
    {

    }

    public override void tarikUang(double jumlah)
    {
        if (jumlah > saldo + 100000)
        {
            Console.WriteLine("Penarikan GagaL Karena Melebihi Batas Yang Ditenetukan");
        }
        else
        {
            Console.WriteLine("Penarikan Uang Berhasil");
            saldo -= jumlah;
        }
    }

}