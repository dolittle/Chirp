using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Views;
using Chirp.Events.Chirping;
using Moq;
using read = Chirp.Read.Streams;

namespace Chirp.Read.Specs.Streams
{
    public class Chirps
    {
        public static readonly read.Chirp first_valid_chirp_from_Scott = new read.Chirp()
                                                                       {
                                                                           Id = Guid.NewGuid(),
                                                                           ChirpedBy = Chirpers.Scott,
                                                                           ChirpedAt = DateTime.Now.AddHours(-10),
                                                                           Content = "This is a chirp from Scott",
                                                                       };

        public static readonly read.Chirp second_valid_chirp_from_Scott = new read.Chirp()
                                                                    {
                                                                        Id = Guid.NewGuid(),
                                                                        ChirpedBy = Chirpers.Scott,
                                                                        ChirpedAt = DateTime.Now.AddHours(-9),
                                                                        Content = "This is a chirp from Scott",
                                                                    };

        public static readonly read.Chirp third_valid_chirp_from_Scott = new read.Chirp()
                                                                    {
                                                                        Id = Guid.NewGuid(),
                                                                        ChirpedBy = Chirpers.Scott,
                                                                        ChirpedAt = DateTime.Now.AddHours(-8),
                                                                        Content = "This is a chirp from Scott",
                                                                    };

        public static readonly read.Chirp valid_chirp_from_Hannah = new read.Chirp()
        {
            Id = Guid.NewGuid(),
            ChirpedBy = Chirpers.Hannah,
            ChirpedAt = DateTime.Now.AddHours(-1),
            Content = "This is a chirp from Hannah",
        }; 

        public static IQueryable<read.Chirp> GetAll()
        {
            return new List<read.Chirp>
                       {
                           valid_chirp_from_Hannah,
                           second_valid_chirp_from_Scott,
                           first_valid_chirp_from_Scott,
                           third_valid_chirp_from_Scott
                       }.AsQueryable();
        }

        public static MessageChirped BuildCorrespondingMessageChirpedEventFrom(read.Chirp chirp)
        {
            return new MessageChirped(chirp.ChirpedBy.ChirperId)
                       {
                           ChirpId = chirp.Id,
                           ChirpedBy = chirp.ChirpedBy.ChirperId,
                           Content = chirp.Content,
                           ChirpedAt = chirp.ChirpedAt,
                       };
        }

        public static Mock<IView<read.Chirp>> GetMockedChirpView()
        {
            var view =  new Mock<IView<read.Chirp>>();
            view.Setup(v => v.Query)
                .Returns(GetAll);
            return view;
        }
    }
}