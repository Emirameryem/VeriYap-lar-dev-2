using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriYapılarıÖdev_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste(); // tek yönlü doğrusal liste yapısı


            int Numara;
            string Adi;
            string soyAdi;

            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("numara: "); Numara = int.Parse(Console.ReadLine());
                        Console.Write("Ad: "); Adi = Console.ReadLine();
                        Console.Write("Soyad: "); soyAdi = Console.ReadLine();
                        ogrenciler.ekle(Numara, Adi, soyAdi);
                        break;

                    case 2:
                        Console.Write("numara: "); Numara = int.Parse(Console.ReadLine());
                        ogrenciler.sil(Numara);
                        break;

                    case 3:
                        ogrenciler.yazdir();
                        break;
                    case 4:
                        ogrenciler.sirala();
                        break;
                    case 0:
                        break;

                    default:
                        Console.WriteLine("hatalı seçim yaotınız");
                        break;

                }
                secim = menu();
            }

        }


        private static int menu()
        {
            int secim;
            Console.WriteLine("1-öğrenci ekle");
            Console.WriteLine("2-öğrenci sil");
            Console.WriteLine("3-öğrencileri yazdır");
            Console.WriteLine("4-öğrencileri sırala");
            Console.WriteLine("0-program kapatılıyor");
            Console.Write("seçiniz: ");
            secim = int.Parse(Console.ReadLine());
            return secim;
        }
    }



    class Ogrenci  // Node
    {
        public int Numara;
        public string Adi;
        public string soyAdi;


        public Ogrenci next; // bir sonraki düğümü tutan gösteren işaretçi

        public Ogrenci(int ogrNo, string ogrAdi, string ogrSoyadi)
        {
            this.Numara = ogrNo;
            this.Adi = ogrAdi;
            this.soyAdi = ogrSoyadi;

            next = null;
        }
    }

    class Liste // öğrencilerin kayıt edildiği liste
    {
        Ogrenci head; // listenin en başındaki düğüm 

        public Liste()
        {
            head = null;
        }

        public void ekle(int ogrNo, string ogrAdi, string ogrSoyadi)
        {
            Ogrenci ogr = new Ogrenci(ogrNo, ogrAdi, ogrSoyadi);

            if (head == null) // ilk eleman boş mu 
            {
                head = ogr; // boşsa öğrenciyi başa ekle
                Console.WriteLine(ogrNo + "numaralı öğrenci listeye eklendi");
            }
            else
            {
                ogr.next = head; // ilk düğüm boş olmadığı için yeni bir düğüm olan ogr nin nexti eski düğümü gösterecek
                head = ogr; // ilk düğüm artık ogr oldu
                Console.WriteLine(ogrNo + "numaralı öğrenci listeye eklendi");

            }
        }

        public void sil(int ogrNo)
        {
            bool sonuc = false;
            if (head == null) // liste boşsa
            {
                sonuc = true;
                Console.WriteLine("listede kayıtlı öğrenci yok.");
            }

            else if (head.next == null && head.Numara == ogrNo) // listede bir öğrenci varsa ve kayıtlı olan tek öğrenciyi mi silmek istiyorsun  
            {
                sonuc = true;
                head = null;
                Console.WriteLine(ogrNo + "numaralı öğrenci silindi, listede hiç öğrenci kalmadı.");
            }

            else if (head.next == null && head.Numara == ogrNo) // listede başta olan öğrenciyi silmek 
            {
                sonuc = true;
                head = head.next;
                Console.WriteLine(ogrNo + "numaralı öğrenci silindi.");
            }
            else // silmek istediğimiz öğrencnin numarasını yazıp silme
            {
                Ogrenci temp = head;
                Ogrenci temp2 = head;

                while (temp.next != null) // son düğüme kadar git ara
                {
                    if (ogrNo == temp.Numara)
                    {
                        sonuc = true;
                        temp2.next = temp.next;
                        Console.WriteLine(ogrNo + "numaralı öğrenci silindi");

                    }
                    temp2 = temp; // temp bir sonraki düğüme geçince öncekini temp2 ye versin
                    temp = temp.next;
                }
                if (ogrNo == temp.Numara)
                {
                    sonuc = true;
                    temp2.next = null;
                    Console.WriteLine(ogrNo + "numaralı öğrenci silindi");

                }
            }

            if (sonuc == false)
            {
                Console.WriteLine(ogrNo + "numaralı öğrenci yoktur");
            }



        }

        public void yazdir() // listedeki öğrencileri yazdırma
        {
            if (head == null)
            {
                Console.WriteLine("listede öğrenci yok");
            }
            else
            {
                Ogrenci temp = head;

                Console.WriteLine("Numara\tAD\tSoyad");
                while (temp.next != null)
                {
                    Console.WriteLine(temp.Numara + "\t" + temp.Adi + "\t" + temp.soyAdi);

                    temp = temp.next;

                }
                Console.WriteLine(temp.Numara + "\t" + temp.Adi + "\t" + temp.soyAdi);

            }

        }

        public void sirala() // selection sort
        {
            if (head == null || head.next == null)
            {
                return; // Liste boş veya tek bir eleman var, sıralama gerekli değil
            }

            Ogrenci current = head;
            while (current != null)
            {
                Ogrenci minNode = current;
                Ogrenci nextNode = current.next;

                while (nextNode != null)
                {
                    if (nextNode.Numara < minNode.Numara)
                    {
                        minNode = nextNode; // Küçük numaralı düğüm bulunur
                    }
                    nextNode = nextNode.next;
                }

                // Değerleri değiştirerek düğümleri takas et
                if (minNode != current)
                {
                    int tempNumber = current.Numara;
                    string tempName = current.Adi;
                    string tempSurname = current.soyAdi;

                    current.Numara = minNode.Numara;
                    current.Adi = minNode.Adi;
                    current.soyAdi = minNode.soyAdi;

                    minNode.Numara = tempNumber;
                    minNode.Adi = tempName;
                    minNode.soyAdi = tempSurname;
                }

                current = current.next;
            }
            Console.WriteLine("Öğrenciler numaralarına göre sıralandı.");
            yazdir();
        }







    }
}
