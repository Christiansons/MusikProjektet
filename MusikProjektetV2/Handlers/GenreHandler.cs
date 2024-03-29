﻿using MusikProjektetV2.Data;
using MusikProjektetV2.Models.Dtos;
using MusikProjektetV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MusikProjektetV2.Models.ViewModels;

namespace MusikProjektetV2.Handlers
{
    public interface IGenreHelper
    {
        IResult AddGenre();
    }
    public class GenreHandler
    {
        //OPTIONAL När man lägger till en genre, hämta liknande låtar från externt API, fråga om man vill lägga till

        //POST /genre lägger till en ny genre
        public static IResult AddGenre(ApplicationContext context, GenreDto genre)
        {
            context.Genres.Add(new Genre
            {
                GenreName = genre.GenreName,
                UserId = genre.UserId
                //Artist = song.Artist,
            });
            try
            {
                context.SaveChanges();
                return Results.StatusCode((int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex);
            }
        }

        //GET /genre Hämta alla genrer i databasen
        public static IResult GetAllGenresConnectedToPerson(ApplicationContext context, int userId)
        {
            ListGenreToPersonViewModel[]? GenreList = context.Genres.Where(x => x.UserId == userId)
                .Select(s => new ListGenreToPersonViewModel
                {
                    GenreName = s.GenreName
                }).ToArray();


            if (GenreList == null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Json(GenreList);
            }
        }

    }
}
