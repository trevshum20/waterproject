﻿using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WaterProject.Infrastructure;

// we could've put this all in one class
// but we want the session stuff to all be self sufficient
// so we inherit and stuff

namespace WaterProject.Models
{
    public class SessionBasket : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionBasket basket = session?.GetJson<SessionBasket>("Basket") ?? new SessionBasket();
            basket.Session = session;
            return basket;
        }

        [JsonIgnore]
        public ISession Session {get; set;}

        public override void AddItem(Project proj, int qty)
        {
            base.AddItem(proj, qty); //  base means use the base class method add item, then
            Session.setJson("Basket", this);  // this is stuff we added on special for this session model
                            // "Basket" is the json of basket that we created...
        }

        public override void RemoveItem(Project proj)
        {
            base.RemoveItem(proj);
            Session.setJson("Basket", this);
        }

        public override void ClearBasket()
        {
            base.ClearBasket();
            Session.Remove("Basket");
        }
    }
}
