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
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "8:30", Name="Подъем, завтрак", Description="", TaskType = PPTaskType.None, AreaId = "Моцион" },
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "10:00", Name="Сходить в магазин за подарком к маме", Description="Выбрать духи", TaskType = PPTaskType.Urgent_Important, AreaId = "Семья" },
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "12:30", Name="Встреча с Николаем", Description="Обсудить планы на каникулы", TaskType = PPTaskType.NonUrgent_Unimportant, AreaId = "Друзья" },
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "15:30", Name="Тренировка в зале", Description="Сушка", TaskType = PPTaskType.Nonurgent_Important, AreaId = "Спорт" },
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "18:30", Name="Сходить в магазин с Ваней", Description="Помочь выбрать кроссовки", TaskType = PPTaskType.Urgent_Unimportant, AreaId = "Друзья" },
                new PPTask { Id = Guid.NewGuid().ToString(), DateTime = "19:00", Name="День рождения у мамы", Description="Семейное торжество", TaskType = PPTaskType.Nonurgent_Important, AreaId = "Семья" },
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
