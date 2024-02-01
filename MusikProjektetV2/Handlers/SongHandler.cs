using MusikProjektetV2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusikProjektetV2.Models;
using System.Net;
using MusikProjektetV2.Models.Dtos;
using MusikProjektetV2.Models.ViewModels;
using System.Text.Json;

namespace MusikProjektetV2.Handlers
{

	public class SongHandler
	{
		public static ApplicationContext context;

		public SongHandler(ApplicationContext Context)
		{
			context = Context;
		}

		//OPTIONAL När man lägger till en låt, hämta liknande låtar från externt API, fråga om man vill lägga till

		//POST /song lägger till en ny låt, den ska ha en genre och artist
		public static IResult AddSong(SongDto song, int artistId, int genreId)
        {
			Artist? artist = context.Artists
				.Where(a => a.Id == artistId)
				.FirstOrDefault();

			Genre? genre = context.Genres
				.Where(g => g.Id == genreId)
				.FirstOrDefault();

            context.Songs.Add(new Song
			{
				SongTitle = song.SongTitle,
				Artist = artist,
				Genre = genre
			});

			if(artist == null || genre == null)
			{
				return Results.NotFound();
			}
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

		//GET /song hämtar alla sånger i databasen
		public static IResult GetAllSongConnectedToUser(int id)
		{
			User? user = context.Users
				.Where(u => u.Id == id)
				.Include(u => u.Songs)
				.FirstOrDefault();

			ListSongViewModel[]? UserSongList = user.Songs
				.Select(s => new ListSongViewModel
				{
					SongTitle= s.SongTitle
				}).ToArray();

			if (UserSongList == null)
			{
				return Results.NotFound();
			}
			else
			{
				return Results.Json(UserSongList);
			}
		}

	}

}
