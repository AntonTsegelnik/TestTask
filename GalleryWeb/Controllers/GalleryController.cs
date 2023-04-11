using Data.Sql;
using GalleryWeb.Models;
using GalleryWeb.Services.IImageServices;
using Microsoft.AspNetCore.Mvc;


namespace GalleryWeb.Controllers
{
    public class GalleryController : Controller
    {
        private IImageService _imageService;
        private ICommentService _commentService;
        private WebContext _webContext;

        public GalleryController(IImageService imageService, WebContext webContext, ICommentService commentService)
        {
            _imageService = imageService;
            _webContext = webContext;
            _commentService = commentService;
        }

// Images
        public IActionResult Index()
        {
            var currentImagesViewModel = _imageService.GetAllImages().Select(x => new ImageViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Url = x.ImageUrl,
            })
               .ToList();


            return View(currentImagesViewModel);
        }

        [HttpGet]
        public IActionResult CreateImage() { 

            return View();
        }

        [HttpPost]
        public IActionResult CreateImage(ImageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _imageService.Save(viewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateImage(int id)
        {
         

            var model = _imageService.Get(id);
       
            var viewModel = new ImageViewModel()
            {

                Id = model.Id,
                Name = model.Name,
                Url = model.ImageUrl
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateImage(ImageViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _imageService.Save(viewModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int[] ids)
        {
            foreach (var id in ids)
            {
                _imageService.Remove(id);
            }

            return RedirectToAction("Index");
        }


// Comments


        public IActionResult Comments()
        {
            var viewModels = _commentService.GetAllComments().Select(x => new CommentViewModel
            {
                Id = x.Id,
                Content = x.Content,
                ImageId = x.Image.Id,
                Date = x.Date,
            }).ToList();

            return View(viewModels);
        }

        [HttpGet]
        public IActionResult CreateComment(int id)
        {
            var viewModel = new CommentViewModel
            {
                ImageId = id,
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateComment(CommentViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel);
            }
            
            _commentService.Save(viewModel);
            return RedirectToAction("Comments");
        }


        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
       
            var model = _commentService.Get(id);
        
            var viewModel = new CommentViewModel()
            {

                Id = model.Id,
                Content = model.Content,
                Date = model.Date,
                ImageId= model.Image.Id,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult UpdateComment(CommentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _commentService.Update(viewModel);
            return RedirectToAction("Comments");
        }


        [HttpPost]
        public IActionResult RemoveComments(int[] ids)
        {
            foreach (var id in ids)
            {
                _commentService.Remove(id);
            }

            return RedirectToAction("Comments");
        }

      
    }
}
