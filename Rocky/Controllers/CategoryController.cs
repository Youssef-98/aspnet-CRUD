﻿using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
  public class CategoryController : Controller
  {
    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      IEnumerable<Category> objList = _db.Category;
      return View(objList);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj)
    {
      if(ModelState.IsValid)
      {
        _db.Category.Add(obj);
        _db.SaveChanges();
        TempData["Message"] = $"{obj.Name} has been added to the list!";
        return RedirectToAction("Index");
      }
      return View(obj);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
      if(id == null || id == 0 )
      {
        return NotFound();
      }
      var obj = _db.Category.Find(id);
      if(obj == null)
      {
        return NotFound();
      }

      return View(obj);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj)
    {
      if (ModelState.IsValid)
      {
        _db.Category.Update(obj);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(obj);
    }

    [HttpGet]
    public IActionResult Delete(int? id)
    {
      var obj = _db.Category.Find(id);
      if (obj != null)
      {
        _db.Category.Remove(obj);
        _db.SaveChanges();
        TempData["Message"] = $"{obj.Name} has been deleted from the list.";
        return RedirectToAction("Index");
      }
      return NotFound();
    }
  }
}
