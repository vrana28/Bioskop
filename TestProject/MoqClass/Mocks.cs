﻿using Bioskop.Domen;
using Bioskop.Podaci;
using Bioskop.Podaci.UnitOfWork;
using Moq;
using System;
using System.Collections.Generic;

namespace TestProject.MoqClass
{
    public class Mocks
    {

        public static Mock<IRepositoryFilm> GetMockFilmRepository()
        {
            var mockFilmRepository = new Mock<IRepositoryFilm>();

            mockFilmRepository.Setup(x => x.VratiSve()).Returns(Films);

            mockFilmRepository.Setup(x => x.NadjiPoId(It.IsAny<int>())).Returns((int f) =>
            {
                return Films().Find(x => x.FilmId==f);
            });

            mockFilmRepository.Setup(x => x.Dodaj(It.IsAny<Film>())).Callback((Film f) =>
             {
                 f.FilmId = 20;
                 Films().Add(f);
             }).Verifiable();

            mockFilmRepository.Setup(r => r.Delete(It.IsAny<Film>())).Callback((Film f) =>
            {
                var filmd = Films().Find(film => film.FilmId == f.FilmId);
                Films().Remove(filmd);
            }).Verifiable();

            return mockFilmRepository;

        }

        public static Mock<IRepositorySala> GetMockSalaRepository()
        {
            var mockSalaRepository = new Mock<IRepositorySala>();

            mockSalaRepository.Setup(x => x.VratiSve()).Returns(Sale);

            mockSalaRepository.Setup(x => x.NadjiPoId(It.IsAny<int>())).Returns((int f) =>
            {
                return Sale().Find(x => x.SalaId == f);
            });

            mockSalaRepository.Setup(x => x.Dodaj(It.IsAny<Sala>())).Callback((Sala s) =>
            {
                s.SalaId = 20;
                Sale().Add(s);
            }).Verifiable();

            mockSalaRepository.Setup(r => r.Delete(It.IsAny<Sala>())).Callback((Sala s) =>
            {
                var sala= Sale().Find(s => s.SalaId == s.SalaId);
                Sale().Remove(sala);
            }).Verifiable();

            return mockSalaRepository;

        }

        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            var mockUnitOfWork = new Mock<IUnitOfWork>();

            mockUnitOfWork.Setup(uow => uow.Film).Returns(GetMockFilmRepository().Object);
            mockUnitOfWork.Setup(uow => uow.Sala).Returns(GetMockSalaRepository().Object);

            mockUnitOfWork.Setup(uow => uow.Commit()).Verifiable();

            return mockUnitOfWork;
        }

        private static List<Film> Films()
        {
            List<Film> filmovi = new List<Film>()
            {
                new Film(){
                    FilmId = 1,
                    Naziv = "Naziv 1",
                    Reziser = "Reziser 1",
                    Zanr = Zanr.Akcija,
                    Trajanje = 123,
                    Godina = 2020,
                    PutanjaPostera = "adada",
                    PutanjaBackPostera = "bgbggbgbg",
                    OpisFilma = "Opis filma 1",
                    YoutubeTrailer = "Youtube trailer 1",
                    Sale = new List<Projekcija>(){
                        new Projekcija(){ }
                    }
                },
                new Film(){
                    FilmId = 2,
                    Naziv = "Naziv 2",
                    Reziser = "Reziser 2",
                    Zanr = Zanr.Komedija,
                    Trajanje = 133,
                    Godina = 2021,
                    PutanjaPostera = "aaaaaa",
                    PutanjaBackPostera = "bbbbb",
                    OpisFilma = "Opis filma 2",
                    YoutubeTrailer = "Youtube trailer 2",
                    Sale = new List<Projekcija>(){
                        new Projekcija(){ }
                    }

                },
                new Film() {
                    FilmId = 3,
                    Naziv = "Naziv 3",
                    Reziser = "Reziser 3",
                    Zanr = Zanr.Komedija,
                    Trajanje = 93,
                    Godina = 2019,
                    PutanjaPostera = "acacacca",
                    PutanjaBackPostera = "popopopopo",
                    OpisFilma = "Opis filma 3",
                    YoutubeTrailer = "Youtube trailer 3",
                    Sale = new List<Projekcija>() {
                        new Projekcija(){ }
                    }
                }
            };
            return filmovi;
        }
            
        private static List<Sala> Sale()
        {
            List<Sala> sale = new List<Sala>()
            {
                new Sala(){
                    SalaId = 1,
                    NazivSale = "Sala 1",
                    SedistaUSali = new List<Sediste>(){ 
                        new Sediste(){ 
                            SedisteId = 1,
                            Red = 'A',
                            Kolona = 1,
                            SlobodnoSediste = true
                        }
                    }
                },
                new Sala(){
                    SalaId = 2,
                    NazivSale = "Sala 2",
                    SedistaUSali = new List<Sediste>(){
                        new Sediste(){
                            SedisteId = 2,
                            Red = 'B',
                            Kolona = 2,
                            SlobodnoSediste = true
                        }
                    }
                },
                new Sala(){
                    SalaId = 3,
                    NazivSale = "Sala 3",
                    SedistaUSali = new List<Sediste>(){
                        new Sediste(){
                            SedisteId = 3,
                            Red = 'C',
                            Kolona = 3,
                            SlobodnoSediste = false
                        }
                    }
                },
            };

            return sale;
        }


    }
}
