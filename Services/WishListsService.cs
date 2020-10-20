using System;
using AmaZen.Models;
using AmaZen.Repositories;

namespace AmaZen.Services
{
  public class WishListsService
  {
    private readonly WishListsRepository _repo;

    public WishListsService(WishListsRepository repo)
    {
      _repo = repo;
    }

    internal WishList GetById(int id)
    {
      var data = _repo.GetById(id);
      if (data == null)
      {
        throw new Exception("Invalid Id");
      }
      return data;
    }

    internal WishList Create(WishList newWishList)
    {
      return _repo.Create(newWishList);
    }

    internal WishList Edit(WishList update)
    {
      var original = GetById(update.Id);
      if (original == null)
      {
        throw new Exception("Bad Request");
      }
      update.Title = update.Title != null ? update.Title : original.Title;
      return _repo.Edit(update);
    }

    internal String Delete(int id)
    {
      var original = GetById(id);
      if (original == null)
      {
        throw new Exception("Bad Request");
      }
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}