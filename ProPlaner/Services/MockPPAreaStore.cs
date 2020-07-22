using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProPlaner.Models;

namespace ProPlaner.Services
{
    public class MockPPAreaStore : IDataStore<PPArea>
    {
        readonly List<PPArea> items;

        public MockPPAreaStore()
        {
            items = new List<PPArea>()
            {
                new PPArea { Id = "Разное", Name = "Разное", Description="Пожиратель времени" },
                new PPArea { Id = "Учеба", Name = "Учеба", Description="Моя учеба" },
                new PPArea { Id = "Спорт", Name = "Спорт", Description="Спортивная секеция" },
                new PPArea { Id = "Мероприятия", Name = "Мероприятия", Description="Культурные события" },
                new PPArea { Id = "Друзья", Name = "Друзья", Description="Посиделки, гулянки, др" }
            };
        }

        public async Task<bool> AddItemAsync(PPArea item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PPArea item)
        {
            var oldItem = items.Where((PPArea arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((PPArea arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<PPArea> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PPArea>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
