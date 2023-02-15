using Microsoft.AspNetCore.Mvc;
using RedAcademySite.Models;
using static System.Net.WebRequestMethods;
using System.Numerics;
using System.Security.AccessControl;
using System.Text;

namespace RedAcademySite.Controllers
{
    public class ConsultantController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var consultantsList = GetConsultants(); //Receives consultant list

            return View(consultantsList.ToList().OrderBy(c => c.Id)); //returns list ordered by id
        }

        [HttpGet]
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        [Route("Detail")]
        public IActionResult Details(int id)
        {
            var consultant = GetConsultantById(id);

            if (GetConsultantById(id) == null)
                return RedirectToAction("Index");

            return View(consultant);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int id)
        {
            var consultant = GetConsultantById(id);

            if (GetConsultantById(id) == null)
                return RedirectToAction("Index");

            return View(consultant);
        }

        [HttpGet]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var consultant = GetConsultantById(id);

            if (GetConsultantById(id) == null)
                return RedirectToAction("Index");

            return View(consultant);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Consultant consultant)
        {
            if(!ModelState.IsValid)
            {
                TempData["error"] = "There was an error with the Add opertation";
                return View(consultant);
            }

            TempData["success"] = "The consultant " + consultant.Name + " with ID " + consultant.Id + " was successfuly added!";
            return RedirectToAction("Index");

            
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(int id, Consultant consultant)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "There was an error with the Add opertation";
                return View(consultant);
            }

            TempData["success"] = "The consultant " + consultant.Name + " with ID " + consultant.Id + " was successfuly edited!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(Consultant consultant)
        {
            if (consultant.Id == null)
            {
                TempData["error"] = "There was an error with the Delete opertation";
                return View(consultant);
            }

            TempData["success"] = "The consultant " + consultant.Name + " with ID " + consultant.Id + " was successfuly deleted!";
            return RedirectToAction("Index");
        }

        private Consultant GetConsultantById(int id) 
        {
            var consultant = GetConsultants().ToList().FirstOrDefault(c => c.Id == id);
           
            if (consultant == null)
                TempData["error"] = "There was an error with the ID provided";

            return consultant;
        }


        private List<Consultant> GetConsultants()
        {
            var consultants = new List<Consultant>()
            {
                    new Consultant
                    {
                        Id = 10,
                        Name = "Carlos Freire",
                        Role = "Tech Lead/Software Architect",
                        Email = "carlos.freire@redit.pt",
                        Team = "DC&RL",
                        Image = "https://secure.gravatar.com/avatar/d417fdf1a35ad619d248c7608f45a560?d=https%3A%2F%2Favatar-management--avatars.us-west-2.prod.public.atl-paas.net%2Finitials%2FCF-2.png",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 11,
                        Name = "Bruno Pólvora",
                        Role = "Fullstack Developer",
                        Email = "bruno.polvora@redit.pt",
                        Team = "DC&RL",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/62d13ca35d6f5fd2c3daafb6/50db066f-0e92-4f0d-99da-d849e4fc06d2/128",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 12,
                        Name = "Aline Neutgem",
                        Role = "Business Function Analist",
                        Email = "aline.neutgem@redit.pt",
                        Team = "DC&RL",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63c570fe176040ff3bd166a5/2662cb5e-87ca-41a6-8e96-2c8b8b7696b0/128",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 1,
                        Name = "Joao Passos",
                        Role = "Developer",
                        Email = "joao.passos@redit.pt",
                        Team = "Red Academy",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e102de614cb4ba530199a4/bf21b7bd-1c6a-436b-8dc8-1451210f4f00/128",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 2,
                        Name = "Diogo Delgado",
                        Role = "Developer",
                        Email = "diogo.delgado@redit.pt",
                        Team = "Red Academy",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e0f177f1475ad42c5b344b/dbaf6da3-2324-4fd3-bec2-0e54f7fcd502/128",
                        Active = true
                    },
                   new Consultant
                   {
                       Id = 3,
                       Name = "Margarida Ramos",
                       Role = "Developer",
                       Email = "margarida.ramos@redit.pt",
                       Team = "Red Academy",
                       Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e0f17a010d35637973cb5e/31c4700e-38bc-4a84-bb24-95a6c8fcfdff/128",
                       Active = true
                   },
                    new Consultant
                    {
                        Id = 4,
                        Name = "Samuel Luis",
                        Role = "Developer",
                        Email = "samuel.luis@redit.pt",
                        Team = "Red Academy",
                        Image = "https://secure.gravatar.com/avatar/c396021f7a48737deb478ed69e4d24dc?d=https%3A%2F%2Favatar-management--avatars.us-west-2.prod.public.atl-paas.net%2Finitials%2FLC-5.png",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 5,
                        Name = "Luis Queirós",
                        Role = "Developer",
                        Email = "luis.queiros@redit.pt",
                        Team = "Red Academy",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e0f17ddb4f715c9722bd64/13d655b7-0af9-406f-b15f-f9ae69f589e7/128",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 6,
                        Name = "Marcelo Martins",
                        Role = "Developer",
                        Email = "jorge.martins@redit.pt",
                        Team = "Red Academy",
                        Image = "https://secure.gravatar.com/avatar/c396021f7a48737deb478ed69e4d24dc?d=https%3A%2F%2Favatar-management--avatars.us-west-2.prod.public.atl-paas.net%2Finitials%2FLC-5.png",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 7,
                        Name = "Idalina Freitas",
                        Role = "Developer",
                        Email = "idalina.freitas@redit.pt",
                        Team = "Red Academy",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e0f18086a66a7cc7a8b0ab/ea8a260c-b4a6-4043-a7ee-c72dd21a818e/128",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 8,
                        Name = "Miguel Rosa",
                        Role = "Developer",
                        Email = "miguel.rosa@redit.pt",
                        Team = "Red Academy",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e0f182491b20ef64bb556e/dd0a767a-0ab6-4c82-9c15-324fce49b372/128",
                        Active = true
                    },
                    new Consultant
                    {
                        Id = 9,
                        Name = "Rafael Palma",
                        Role = "Developer",
                        Email = "rafael.palma@redit.pt",
                        Team = "Red Academy",
                        Image = "https://avatar-management--avatars.us-west-2.prod.public.atl-paas.net/63e0f184010d35637973cb6a/d25ecb0a-9114-4e5b-a435-92103e4248da/128",
                        Active = true
                    }
            };
            return consultants;
        }
    }
}
