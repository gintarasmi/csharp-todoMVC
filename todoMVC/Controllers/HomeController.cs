using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using todoMVC.Models;


namespace todoMVC.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index(TodoListModel todoList)
        {
            if (todoList.todoItems == null) todoList.todoItems = new List<string>();
            //if(todo.newTodo != null) todo.todoItems.Add(todo.newTodo);
            return View(todoList);
        }

        [HttpPost]
        public IActionResult IndexNew([FromForm] TodoListModel todoList)
        {
            if (todoList.todoItems == null) todoList.todoItems = new List<string>();
            if (todoList.newTodo != null) {
                todoList.todoItems.Add(todoList.newTodo);
                todoList.newTodo = "";
            }
            

            return View("Index", todoList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}