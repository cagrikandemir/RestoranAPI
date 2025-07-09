using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public int TActiveCategoryCount()
    {
        return _categoryDal.ActiveCategoryCount();
    }

    public void TAdd(Category entity)
    {
        _categoryDal.Add(entity);
    }

    public int TCategoryCount()
    {
        return _categoryDal.CategoryCount();
    }

    public void TDelete(Category entity)
    {
       _categoryDal.Delete(entity);
    }

    public List<Category> TGetAllList()
    {
       return _categoryDal.GetAllList();
    }

    public Category TGetById(int Id)
    {
        return _categoryDal.GetById(Id);
    }

    public int TPassiveCategoryCount()
    {
        return _categoryDal.PassiveCategoryCount();
    }

    public void TUpdate(Category entity)
    {
        _categoryDal.Update(entity);
    }
}
