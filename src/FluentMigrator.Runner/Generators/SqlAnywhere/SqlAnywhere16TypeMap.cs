﻿using System.Data;
using FluentMigrator.Runner.Generators.Base;

namespace FluentMigrator.Runner.Generators.SqlAnywhere
{
    public class SqlAnywhere16TypeMap : TypeMapBase
    {
        public const int AnsiStringCapacity = 8000;
        public const int AnsiTextCapacity = 2147483647;
        public const int UnicodeStringCapacity = 4000;
        public const int UnicodeTextCapacity = 1073741823;
        public const int ImageCapacity = 2147483647;
        public const int DecimalCapacity = 38;

        protected override void SetupTypeMaps()
        {
            SetTypeMap(DbType.AnsiStringFixedLength, "CHAR(255)");
            SetTypeMap(DbType.AnsiStringFixedLength, "CHAR($size)", AnsiStringCapacity);
            SetTypeMap(DbType.AnsiString, "VARCHAR(255)");
            SetTypeMap(DbType.AnsiString, "VARCHAR($size)", AnsiStringCapacity);
            SetTypeMap(DbType.AnsiString, "TEXT", AnsiTextCapacity);
            SetTypeMap(DbType.Binary, "VARBINARY(8000)");
            SetTypeMap(DbType.Binary, "VARBINARY($size)", AnsiStringCapacity);
            SetTypeMap(DbType.Binary, "IMAGE", ImageCapacity);
            SetTypeMap(DbType.Boolean, "BIT");
            SetTypeMap(DbType.Byte, "TINYINT");
            SetTypeMap(DbType.Currency, "MONEY");
            SetTypeMap(DbType.Date, "DATE");
            SetTypeMap(DbType.DateTime, "DATETIME");
            SetTypeMap(DbType.DateTimeOffset, "TIMESTAMP WITH TIME ZONE");
            SetTypeMap(DbType.Decimal, "DECIMAL(30,6)");
            SetTypeMap(DbType.Decimal, "DECIMAL($size,$precision)", DecimalCapacity);
            SetTypeMap(DbType.Double, "DOUBLE PRECISION");
            SetTypeMap(DbType.VarNumeric, "NUMERIC(30,6)");
            SetTypeMap(DbType.VarNumeric, "NUMERIC($size,$precision)", DecimalCapacity);
            SetTypeMap(DbType.Guid, "UNIQUEIDENTIFIER");
            SetTypeMap(DbType.Int16, "SMALLINT");
            SetTypeMap(DbType.Int32, "INTEGER");
            SetTypeMap(DbType.Int64, "BIGINT");
            SetTypeMap(DbType.Single, "REAL");
            SetTypeMap(DbType.StringFixedLength, "NCHAR(255)");
            SetTypeMap(DbType.StringFixedLength, "NCHAR($size)", UnicodeStringCapacity);
            SetTypeMap(DbType.String, "NVARCHAR(255)");
            SetTypeMap(DbType.String, "NVARCHAR($size)", UnicodeStringCapacity);
            // Officially this is 1073741823 but we will allow the int.MaxValue Convention
            SetTypeMap(DbType.String, "NTEXT", int.MaxValue);
            SetTypeMap(DbType.Time, "DATETIME");
            SetTypeMap(DbType.Xml, "XML");
        }
    }
}