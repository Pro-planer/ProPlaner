using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProPlaner.Models;

namespace ProPlaner.Services
{
    class MockPPTaskStore : IDataStore<PPTask>
    {
        readonly List<PPTask> items;

        public MockPPTaskStore()
        {
            items = new List<PPTask>()
            {
               /* new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },*/
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "18:30 22.07.2020", Name="Тренировка в зале", Description="Сушка", TaskType = PPTaskType.Nonurgent_Important, AreaId = "Спорт" }
            };
        }

        public async Task<bool> AddItemAsync(PPTask item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(PPTask item)
        {
            var oldItem = items.Where((PPTask arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((PPTask arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<PPTask> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<PPTask>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
