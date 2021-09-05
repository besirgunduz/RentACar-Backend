namespace Core.CrossCuttingConcerns.Caching
{
    interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //Cache'de varmı?
        void Remove(string key);
        void RemoveByPattern(string pattern); // pattern'a uyanların tamamını silmek için

    }
}
