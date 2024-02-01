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

namespace MusikProjektetV2.Handlers
{
	public interface ISongHelper
	{
		IResult AddSong();
	}

	public class SongHandler
	{
		//OPTIONAL När man lägger till en låt, hämta liknande låtar från externt API, fråga om man vill lägga till

		//POST /song lägger till en ny låt, den ska ha en genre och artist
		public static IResult AddSong(ApplicationContext context, SongDto song)
        {
            context.Songs.Add(new Song
			{
				SongTitle = song.SongTitle,
				//Genre = song.Genre,
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

		//GET /song hämtar alla sånger i databasen
		public static IResult GetAllSongs(ApplicationContext context)
		{
			ListSongViewModel[]? SongList = context.Songs
				.Select(s => new ListSongViewModel
				{
					SongTitle= s.SongTitle
				}).ToArray();

			if (SongList == null)
			{
				return Results.NotFound();
			}
			else
			{
				return Results.Json(SongList);
			}
		}

        

    }
}
