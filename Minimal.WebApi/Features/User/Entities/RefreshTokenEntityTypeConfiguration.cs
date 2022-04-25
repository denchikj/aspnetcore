﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Minimal.WebApi.Features.User.Entities;

internal class RefreshTokenEntityTypeConfiguration : IEntityTypeConfiguration<RefreshTokenEntity>
{
    public void Configure(EntityTypeBuilder<RefreshTokenEntity> entity)
    {
        entity.ToTable("refresh_tokens");

        entity
            .HasKey(refreshToken => refreshToken.Id)
            .HasName("pk_refresh_tokens");

        entity
            .Property(refreshToken => refreshToken.Id)
            .HasColumnName("id");

        entity
            .Property(refreshTokenEntity => refreshTokenEntity.UserId)
            .HasColumnName("user_id");

        entity
            .Property(refreshToken => refreshToken.ExpirationTime)
            .HasColumnName("expiration_time");
    }
}