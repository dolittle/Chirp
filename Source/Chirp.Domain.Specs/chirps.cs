using System;
using Chirp.Concepts;

namespace Chirp.Domain.Specs
{
    public class chirps
    {
        public static readonly Domain.Chirping.Chirp valid_chirp_with_no_tags = new Domain.Chirping.Chirp { Id = Guid.NewGuid(), Content = "This is a message with no tags." };
        public static readonly Domain.Chirping.Chirp invalid_id = new Domain.Chirping.Chirp { Content = "This message has no message Id." };
        public static readonly Domain.Chirping.Chirp empty = new Domain.Chirping.Chirp { Id = Guid.NewGuid(), Content = string.Empty };
        public static readonly Domain.Chirping.Chirp max_length = new Domain.Chirping.Chirp { Id = Guid.NewGuid(), Content = new string('A', Domain.Chirping.Chirp.MaxLength) };
        public static readonly Domain.Chirping.Chirp too_long = new Domain.Chirping.Chirp { Id = Guid.NewGuid(), Content = new string('B', Domain.Chirping.Chirp.MaxLength + 1) };
        public static readonly Domain.Chirping.Chirp duplicate = new Domain.Chirping.Chirp { Id = Guid.NewGuid(), Content = "This is a duplicate message" };
        public static readonly ChirpId does_not_exist = Guid.NewGuid();
        public static readonly ChirpId from_a_different_chirper = Guid.NewGuid();
    }
}