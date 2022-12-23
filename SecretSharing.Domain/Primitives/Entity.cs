﻿using System;

namespace SecretSharing.Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Guid Guid { get; private set; } = Guid.NewGuid();

        public Entity()
        {

        }

        public static bool operator ==(Entity first, Entity second)
        {
            return first is not null && second is not null && first.Equals(second);
        }
        public static bool operator !=(Entity first, Entity second)
        {
            return !(first == second);
        }

        public bool Equals(Entity other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }
            return other.Guid == Guid;

        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (obj is not Entity entity)
            {
                return false;
            }

            return entity.Guid == Guid;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode() * 12;
        }


    }
}