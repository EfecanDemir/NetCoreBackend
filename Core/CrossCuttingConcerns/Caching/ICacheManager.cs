using System;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        // bir cacahe ile yapilacak islemlerin imzasi yazilir
        T Get<T>(string key); // cache degerini okur
        object Get(string key);
        // cache ekler ,duration --> cache de durma suresi
        void Add(string key, object data, int duration);
        bool IsAdded(string key);// cacheden mi getirilsin?
        void Remove(string key); // cacheden silme
        void RemoveByPattern(string pattern); // bir pattern verilerek silinmesi --> ornek get ile baslayanlari sil

    }
}