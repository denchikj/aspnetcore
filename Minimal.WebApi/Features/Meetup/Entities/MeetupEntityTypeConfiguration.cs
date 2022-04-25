﻿namespace Minimal.WebApi.Features.Meetup.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Minimal.WebApi.Features.User.Entities;

internal class MeetupEntityTypeConfiguration : IEntityTypeConfiguration<MeetupEntity>
{
    public void Configure(EntityTypeBuilder<MeetupEntity> entity)
    {
        entity.ToTable("meetups");

        entity
            .HasKey(meetup => meetup.Id)
            .HasName("pk_meetups");

        entity
            .HasMany(meetup => meetup.SignedUpUsers)
            .WithMany(user => user.SignedUpMeetups)
            .UsingEntity<Dictionary<string, object>>(
                "meetups_signed_up_users",
                joinEntity => joinEntity
                    .HasOne<UserEntity>()
                    .WithMany()
                    .HasForeignKey("user_id")
                    .HasConstraintName("fk_meetups_signed_up_users"),
                joinEntity => joinEntity
                    .HasOne<MeetupEntity>()
                    .WithMany()
                    .HasForeignKey("meetup_id")
                    .HasConstraintName("fk_users_signed_up_meetups"),
                joinEntity =>
                {
                    joinEntity
                        .HasKey("user_id", "meetup_id")
                        .HasName("pk_meetups_signed_up_users");

                    joinEntity
                        .HasIndex("meetup_id")
                        .HasDatabaseName("ix_meetups_signed_up_users_meetup_id");
                });

        entity
            .Property(meetup => meetup.Id)
            .HasColumnName("id");

        entity
            .Property(meetup => meetup.Topic)
            .HasColumnName("topic");

        entity
            .Property(meetup => meetup.Place)
            .HasColumnName("place");

        entity
            .Property(meetup => meetup.Duration)
            .HasColumnName("duration");
    }
}
