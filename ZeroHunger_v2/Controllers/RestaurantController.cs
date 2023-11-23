using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZeroHunger_v2.Models;
using ZeroHunger_v2.DTOs;


namespace ZeroHunger_v2.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        [Log]
        public ActionResult Dashboard()
        {
            return View();
        }
        [Log]
        [HttpGet]
        public ActionResult CreateNewRequest()
        {
            return View();
        }
        [HttpPost]

        public ActionResult CreateNewRequest(RequestDTO request)
        {


            if (ModelState.IsValid)
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RequestDTO, Request>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<Request>(request);

                var db = new ZeroHungerContainer();
                db.Requests.Add(data);
                db.SaveChanges();

                return RedirectToAction("PendingRequest");
            }
            return View(request);
        }
        [Log]
        public ActionResult PendingRequest()
        {
            var id = Convert.ToInt32(Session["restaurantid"]);
            var db = new ZeroHungerContainer();
            var data = (from requests in db.Requests
                        where requests.RestaurantID == id && requests.Status == "Requested"
                        select requests).ToList();

            return View(data);
        }
        public ActionResult DeleteRequest(int id)
        {
            var db = new ZeroHungerContainer();
            var data = db.Requests.Find(id);
            db.Requests.Remove(data);
            db.SaveChanges();

            return RedirectToAction("PendingRequest");
        }
        [Log]
        public ActionResult DonateHistory()
        {
            var id = Convert.ToInt32(Session["restaurantid"]);
            var db = new ZeroHungerContainer();
            var data = (from requests in db.Requests
                        where requests.RestaurantID == id && requests.Status == "Completed"
                        select requests).ToList();

            return View(data);
        }

        [Log]
        [HttpGet]
        public ActionResult AddRestaurant()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddRestaurant(RestaurantDTO res)
        {


            if (ModelState.IsValid)
            {

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<RestaurantDTO, Restaurant>();
                });
                var mapper = new Mapper(config);
                var data = mapper.Map<Restaurant>(res);

                var db = new ZeroHungerContainer();
                db.Restaurants.Add(data);
                db.SaveChanges();

                return RedirectToAction("RedirectRestaurant");
            }
            return View(res);
        }

        public ActionResult RedirectRestaurant()
        {
            var id = Convert.ToInt32(Session["id"]);
            var db = new ZeroHungerContainer();
            var resdata = (from r in db.Restaurants
                           where r.RestaurantOwnerID == id
                           select r).SingleOrDefault();
            if (resdata != null)
            {
                Session["restaurantid"] = resdata.RestaurantID;
                Session["restaurantname"] = resdata.RestaurantName;
                Session["restaurantlocation"] = resdata.RestaurantLocation;
                Session["restaurantcontactperson"] = resdata.RestaurantContactPerson;
                Session["restaurantcontactnumber"] = resdata.RestaurantContactNumber;
                Session["restaurantemail"] = resdata.RestaurantEmail;
                Session["restaurantownerid"] = resdata.RestaurantOwnerID;


                return RedirectToAction("Dashboard");
            }

            return RedirectToAction("AddRestaurant", "Restaurant");
        }




    }
}