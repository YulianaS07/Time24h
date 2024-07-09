using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace czas24
{
    public class Czas24h
    {
        private int liczbaSekund;

        public int Sekunda
        {
            get => liczbaSekund - Godzina * 60 * 60 - Minuta * 60;
            set
            {
                    if (value < 0 || value >= 60)
                        throw new ArgumentException("error");

                    int cz_bez_sek = liczbaSekund - (liczbaSekund - Godzina * 60 * 60 - Minuta * 60);
                    liczbaSekund = cz_bez_sek + value;
            }
        }

        public int Minuta
        {
            get => (liczbaSekund / 60) % 60;
            set
            {
                if (value <= 0 || value >= 60)
                    throw new ArgumentException("error");

                int cz_bez_min = liczbaSekund - (((liczbaSekund / 60) % 60)*60);
                liczbaSekund = cz_bez_min + (value * 60);
            }
        }

        public int Godzina
        {
            get => liczbaSekund / 3600;
            set
            {
                if (value < 0 || value >= 24)
                    throw new ArgumentException("error");

                int cz_bez_god = liczbaSekund - (liczbaSekund / 3600 * 3600);
                liczbaSekund = cz_bez_god + (value * 3600);
            }
        }

        public Czas24h(int godzina, int minuta, int sekunda)
        {
            if (sekunda < 0 || sekunda >= 60 || minuta < 0 || minuta >= 60 || godzina < 0 || godzina >= 24)
                throw new ArgumentException("error");

            liczbaSekund = sekunda + 60 * minuta + 3600 * godzina;
        }

        public override string ToString() => $"{Godzina}:{Minuta:D2}:{Sekunda:D2}";
    }
}
