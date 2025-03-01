﻿using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;
using System.Collections.Generic;

namespace Rocky.Controllers
{
  public class ApplicationTypeController : Controller
  {
    private readonly ApplicationDbContext _db;

    public ApplicationTypeController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      IEnumerable<ApplicationType> objList = _db.ApplicationType;
      return View(objList);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ApplicationType obj)
    {
      _db.ApplicationType.Add(obj);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
