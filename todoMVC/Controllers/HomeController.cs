using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using todoMVC.Data;
using todoMVC.Models;


namespace todoMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly MVCDBContext _context;

        public HomeController(MVCDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(TodoListModel todoList)
        {
            if (todoList.todoItems == null) todoList.todoItems = new List<TodoItem>();
            foreach (var item in _context.TodoItems)
            {
                todoList.todoItems.Add(item);
            }
            
            //if(todo.newTodo != null) todo.todoItems.Add(todo.newTodo);
            return View(todoList);
        }

        [HttpPost("uhh")]
        public IActionResult IndexNew([FromForm] TodoListModel todoList)
        {
            if (todoList.newTodo != null) {
                var todoItem = new TodoItem();
                todoItem.Title = todoList.newTodo;
                _context.TodoItems.Add(todoItem);
                _context.SaveChanges();
                todoList.newTodo = "";
            }
            return RedirectToAction("Index");
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            TodoItem? itemToDelete = _context.TodoItems.Where(todoItem => todoItem.Id.Equals(id)).FirstOrDefault();
            if (itemToDelete != null)
            {
                _context.TodoItems.Remove(itemToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}