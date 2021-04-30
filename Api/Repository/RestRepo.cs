using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Repository
{
    public interface Irep
    {
        List<M_RESTAURANT> GetAll();
        M_RESTAURANT GetRestaurantDetails(int id);
        void createRestaurant(M_RESTAURANT c);
        void deleteRestaurant(int id);
        void updateRestaurant(M_RESTAURANT c);
    }

    public class RestRepo
    {
        demoCaseStudyApiEntities entity = new demoCaseStudyApiEntities();

        public List<M_RESTAURANT> GetAll()
        {
            return entity.M_RESTAURANT.ToList();
        }

        public M_RESTAURANT GetRestaurantDetails(int id)
        {
            M_RESTAURANT x = entity.M_RESTAURANT.ToList().Find(i => i.Id == id);
            return x;
        }

        public void createRestaurant(M_RESTAURANT c)
        {
            entity.M_RESTAURANT.Add(c);
            entity.SaveChanges();
        }

        public void deleteRestaurant(int id)
        {
            M_RESTAURANT c = entity.M_RESTAURANT.Find(id);
            entity.M_RESTAURANT.Remove(c);
            entity.SaveChanges();
        }

        public void updateRestaurant(M_RESTAURANT c)
        {
            entity.Entry(c).State = EntityState.Modified;
            entity.SaveChanges();
        }
    }
}