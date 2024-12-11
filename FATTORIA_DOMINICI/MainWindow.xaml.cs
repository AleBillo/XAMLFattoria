using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FATTORIA_DOMINICI
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public class Fattoria
        {
            public Fattoria()
            {
                Animali = new List<Animale>();
            }
            public List<Animale> Animali { get; set; }


            public void AggiungiAnimali(Animale a1)
            {
                Animali.Add(a1);
            }

            public void TogliAnimale(int id)
            {
                int i = 0;
                foreach (Animale d in Animali)
                {
                    if (d.Id == Animali[i].Id)
                    {
                        Animali.Remove(d);
                    }
                    i++;
                }
            }

            public int SommaTutti()
            {
                
                int somma = 0;
                foreach(Animale a in Animali)
                {
                    somma = somma + a.Prezzo;
                }

                return somma;
            }
        }
        public abstract class Animale
        {
            public Animale()
            {

            }
            public double Peso { get; set; }
            public int Età { get; set; }

            public char Sesso { get; set; }

            public int Id { get; set; }
            public int Prezzo { get; set; }



            public virtual void Crescita()
            {
                throw new System.NotImplementedException();
            }

            public virtual string Necessità()
            {
                throw new System.NotImplementedException();
            }

            public virtual string Verso()
            {
                throw new System.NotImplementedException();
            }

            public virtual int EtaAnimale()
            {
                throw new System.NotImplementedException();
            }

        }
        public class Mammiferi:Animale
        {
            public int LitriLatte { get; set; }
            public Fabbisogno Fabb { get; set; }

            public virtual int QuantitàLatteProdottiAlMese()
            {
                throw new System.NotImplementedException();
            }
        }
        public class Fabbisogno
        {
            public int AcquaLitri { get; set; }
            public int CiboUSato { get; set; }
            public Fabbisogno(int ac, int cib)
            {
                this.AcquaLitri = ac;
                this.CiboUSato = cib;
            }
        }
        public class Capra:Mammiferi
        {
            public Capra(int e, double p, char s, Fabbisogno fabbisogno, int id)
            {
                Età = e;
                Peso = p;
                Sesso = s;
                Fabb = fabbisogno;
                Id = id;
                Prezzo = 100;
                LitriLatte = 10;
            }

            public override void Crescita()
            {
                 Età += 1;
            }

            public override int EtaAnimale()
            {
                return this.Età;
            }

            public override string Verso()
            {
                return base.Verso() + "Bee";
            }


            public override int QuantitàLatteProdottiAlMese()
            {
                return LitriLatte = LitriLatte * 30;
            }

            public override string Necessità()
            {
                return $"acqua= {Fabb.AcquaLitri}\nCibo al giorno= {Fabb.CiboUSato}";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Fabbisogno fabb = new Fabbisogno(20, 10);
            Animale Capra = new Capra(12,100,'F',fabb,001);
            Fattoria Fatt = new Fattoria();
            Fatt.AggiungiAnimali(Capra);
            Test.Text=Fatt.SommaTutti().ToString();
            TEst2.Text=Fatt.Animali[0].EtaAnimale().ToString();
        }
    }
}
