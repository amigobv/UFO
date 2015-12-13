using System.Collections.Generic;
using Ufo.DAL.Common;
using Ufo.Domain;
using Ufo.DAL.SqlServer;
using Ufo.DAL.SqlServer.Dao;
using Ufo.DAL.Test.Common;
using Xunit;


namespace Ufo.DAL.Test
{  
	public class CategoryTest
	{
        private IList<Category> items;

        private const string CATEGORY_UPDATE_STRING = "Street Comedy";

        private const string COMEDY_LABEL = "Comedy";
        private const string COMEDY_ID = "C";

        private const string AKROBATIK_LABEL = "Akrobatik";
        private const string AKROBATIK_ID = "A";

        private const string MUSIK_LABEL = "Musik";
        private const string MUSIK_ID = "M";

        private const string FEUER_LABEL = "Feuer";
        private const string FEUER_ID = "F";

        private void CreateTestData()
        {
            items = new List<Category>();
            items.Add(new Category(COMEDY_ID, COMEDY_LABEL));
            items.Add(new Category(AKROBATIK_ID, AKROBATIK_LABEL));
            items.Add(new Category(MUSIK_ID, MUSIK_LABEL));
            items.Add(new Category(FEUER_ID, FEUER_LABEL));
        }

        void InsertDummyData(ICategoryDao dao)
        {
            CreateTestData();

            foreach (var item in items)
            {
                dao.Insert(item);
            }
        }

        [Fact]
        [AutoRollback]
        public void InsertCategoryTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var categoryDao = new CategoryDao(database);
            InsertDummyData(categoryDao);
            Assert.Equal(items.Count, categoryDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void FindAllCategoriesTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var categoryDao = new CategoryDao(database);
            InsertDummyData(categoryDao);
            Assert.Equal(items.Count, categoryDao.Count());

            IList<Category> dbCategories = categoryDao.FindAll();
            Assert.NotNull(dbCategories);
            Assert.Equal(items.Count, dbCategories.Count);

            foreach (var cat in dbCategories)
            {
                Assert.True(items.Contains(cat));
            }
        }

        [Fact]
        [AutoRollback]
        public void FindCategoryByIdTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var categoryDao = new CategoryDao(database);
            InsertDummyData(categoryDao);
            Assert.Equal(items.Count, categoryDao.Count());

            Category myCateg = categoryDao.FindById(AKROBATIK_ID);
            Assert.NotNull(myCateg);
            Assert.Equal(AKROBATIK_LABEL, myCateg.Label);

            categoryDao.Delete(myCateg.Id);
            Assert.Equal(3, categoryDao.Count());
        }

        [Fact]
        [AutoRollback]
        public void UpdateCategoryTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            CategoryDao categoryDao = new CategoryDao(database);
            InsertDummyData(categoryDao);
            Assert.Equal(items.Count, categoryDao.Count());


            categoryDao.Update(new Category(COMEDY_ID, CATEGORY_UPDATE_STRING));
            var myNewCateg = categoryDao.FindById(COMEDY_ID);
            Assert.NotNull(myNewCateg);
            Assert.True(!items.Contains(myNewCateg));
            Assert.Equal(CATEGORY_UPDATE_STRING, myNewCateg.Label);
        }

        [Fact]
        [AutoRollback]
        public void DeleteCategoryTest()
        {
            IDatabase database = new Database(TestUtils.ConnString);
            Assert.NotNull(database);

            var categoryDao = new CategoryDao(database);
            InsertDummyData(categoryDao);
            Assert.Equal(items.Count, categoryDao.Count());

            foreach(var item in items)
            {
                categoryDao.Delete(item.Id);
            }
            Assert.Equal(0, categoryDao.Count());
        }
    }
}
