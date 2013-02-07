using System;
using System.Collections.Generic;
using System.Linq;
using Bifrost.Views;
using Chirp.Events.Chirping;
using Moq;

namespace Chirp.Read.Specs
{
    public class Chirps
    {
        public static readonly Read.Streams.Chirp first_valid_chirp_from_Scott = new Read.Streams.Chirp()
                                                                       {
                                                                           Id = Guid.NewGuid(),
                                                                           ChirpedBy = Chirpers.Scott,
                                                                           ChirpedAt = DateTime.Now.AddHours(-10),
                                                                           Content = "This is a chirp from Scott",
                                                                       };

        public static readonly Read.Streams.Chirp second_valid_chirp_from_Scott = new Read.Streams.Chirp()
                                                                    {
                                                                        Id = Guid.NewGuid(),
                                                                        ChirpedBy = Chirpers.Scott,
                                                                        ChirpedAt = DateTime.Now.AddHours(-9),
                                                                        Content = "This is a chirp from Scott",
                                                                    };

        public static readonly Read.Streams.Chirp third_valid_chirp_from_Scott = new Read.Streams.Chirp()
                                                                    {
                                                                        Id = Guid.NewGuid(),
                                                                        ChirpedBy = Chirpers.Scott,
                                                                        ChirpedAt = DateTime.Now.AddHours(-8),
                                                                        Content = "This is a chirp from Scott",
                                                                    };

        public static readonly Read.Streams.Chirp valid_chirp_from_Hannah = new Read.Streams.Chirp()
        {
            Id = Guid.NewGuid(),
            ChirpedBy = Chirpers.Hannah,
            ChirpedAt = DateTime.Now.AddHours(-1),
            Content = "This is a chirp from Hannah",
        }; 

        public static IQueryable<Read.Streams.Chirp> GetAll()
        {
            return new List<Read.Streams.Chirp>
                       {
                           valid_chirp_from_Hannah,
                           second_valid_chirp_from_Scott,
                           first_valid_chirp_from_Scott,
                           third_valid_chirp_from_Scott
                       }.AsQueryable();
        }

        public static MessageChirped BuildCorrespondingMessageChirpedEventFrom(Read.Streams.Chirp chirp)
        {
            return new MessageChirped(chirp.ChirpedBy.ChirperId)
                       {
                           ChirpId = chirp.Id,
                           ChirpedBy = chirp.ChirpedBy.ChirperId,
                           Content = chirp.Content,
                           ChirpedAt = chirp.ChirpedAt,
                       };
        }

        public static Mock<IView<Read.Streams.Chirp>> GetMockedChirpView()
        {
            var view =  new Mock<IView<Read.Streams.Chirp>>();
            view.Setup(v => v.Query)
                .Returns(GetAll);
            return view;
        }
    }
}