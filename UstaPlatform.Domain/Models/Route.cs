using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UstaPlatform.Domain.Models
{
  public class Route : IEnumerable<(int X, int Y)>
    {
        private readonly List<(int X, int Y)> _stops = new();

        // Koleksiyon başlatıcılarda kullanılacak Add metodu
        public void Add(int X, int Y) => _stops.Add((X, Y));

        // IEnumerable arayüzü uygulaması
        public IEnumerator<(int X, int Y)> GetEnumerator() => _stops.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        // Rota üzerindeki toplam durak sayısı
        public int Count => _stops.Count;
    }
}
