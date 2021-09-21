using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Orderable
{
    

    public class SiralamaYap<T> where T : ISiralanabilir
    {
        public void SiraNoYenile(IList<T> liste)
        {
            int siraNo = 0;

            var yeniListe = liste.OrderBy(x => x.SiraNo);

            // Tüm Listeyi al sira nosuna göre al
            foreach (var item in yeniListe)
            {
                siraNo++;

                item.SiraNo = siraNo;
            }
        }

        public void SiraNoDegistir(IList<T> liste, T o, int yeniSiraNo)
        {
            int siraNo = 0;

            var yeniListe = liste.OrderBy(x => x.SiraNo);

            // Tüm Listeyi al sira nosuna göre al
            foreach (var item in yeniListe)
            {
                siraNo++;

                if (siraNo == yeniSiraNo) siraNo++;

                if (item.Equals(o))
                {
                    item.SiraNo = yeniSiraNo;
                    siraNo--;

                }
                else
                {
                    item.SiraNo = siraNo;
                }
            }

            // Tüm Listeyi dön 

            // tüm elemanlara sirano arttırarak sirano ata

            //Eğer elemana istenen siraya geldiyse atla

            // Sıra numarası

           


        }

        public void UsteTasi(IList<T> liste, T o)
        {
            if (o.SiraNo > 1)
            {
                int yeniSiraNo = o.SiraNo - 1;

                this.SiraNoDegistir(liste, o, yeniSiraNo);
            }
        }

        public void AsagiTasi(IList<T> liste, T o)
        {
            if (o.SiraNo < liste.Max(x=>x.SiraNo))
            {
                int yeniSiraNo = o.SiraNo + 1;

                this.SiraNoDegistir(liste, o, yeniSiraNo);
            }
        }

        public void YeniSiraNo(IList<T> liste,T o)
        {
            int i = liste.Max(x => x.SiraNo);

            i++;

            o.SiraNo = i;
        }
    }
}
