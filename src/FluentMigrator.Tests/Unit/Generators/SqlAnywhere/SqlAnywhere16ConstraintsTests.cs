﻿using FluentMigrator.Runner.Generators.SqlAnywhere;
using NUnit.Framework;
using Shouldly;
using System;
using System.Data;

namespace FluentMigrator.Tests.Unit.Generators.SqlAnywhere
{
    [TestFixture]
    public class SqlAnywhere16ConstraintsTests : BaseConstraintsTests
    {
        protected SqlAnywhere16Generator Generator;

        [SetUp]
        public void Setup()
        {
            Generator = new SqlAnywhere16Generator();
        }

        //Todo: This test must be enabled: [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public void CanAlterDefaultConstraintWithCurrentUserAsDefault()
        {
            var expression = GeneratorTestHelper.GetAlterDefaultConstraintExpression();
            expression.DefaultValue = SystemMethods.CurrentUser;

            string expected = "DECLARE @default sysname, @sql nvarchar(max);" + Environment.NewLine + Environment.NewLine +
            "-- get name of default constraint" + Environment.NewLine +
            "SELECT @default = name" + Environment.NewLine +
            "FROM sys.default_constraints" + Environment.NewLine +
            "WHERE parent_object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND type = 'D'" + Environment.NewLine +
            "AND parent_column_id = (" + Environment.NewLine +
            "SELECT column_id" + Environment.NewLine +
            "FROM sys.columns" + Environment.NewLine +
            "WHERE object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND name = 'TestColumn1'" + Environment.NewLine +
            ");" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to drop constraint as string and run it" + Environment.NewLine +
            "SET @sql = N'ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT ' + @default;" + Environment.NewLine +
            "EXEC sp_executesql @sql;" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to create new default constraint as string and run it" + Environment.NewLine +
            "ALTER TABLE [dbo].[TestTable1] WITH NOCHECK ADD CONSTRAINT [DF_TestTable1_TestColumn1] DEFAULT(CURRENT_USER) FOR [TestColumn1];";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        //Todo: This test must be enabled: [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public void CanAlterDefaultConstraintWithCurrentDateAsDefault()
        {
            var expression = GeneratorTestHelper.GetAlterDefaultConstraintExpression();
            expression.DefaultValue = SystemMethods.CurrentDateTime;

            string expected = "DECLARE @default sysname, @sql nvarchar(max);" + Environment.NewLine + Environment.NewLine +
            "-- get name of default constraint" + Environment.NewLine +
            "SELECT @default = name" + Environment.NewLine +
            "FROM sys.default_constraints" + Environment.NewLine +
            "WHERE parent_object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND type = 'D'" + Environment.NewLine +
            "AND parent_column_id = (" + Environment.NewLine +
            "SELECT column_id" + Environment.NewLine +
            "FROM sys.columns" + Environment.NewLine +
            "WHERE object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND name = 'TestColumn1'" + Environment.NewLine +
            ");" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to drop constraint as string and run it" + Environment.NewLine +
            "SET @sql = N'ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT ' + @default;" + Environment.NewLine +
            "EXEC sp_executesql @sql;" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to create new default constraint as string and run it" + Environment.NewLine +
            "ALTER TABLE [dbo].[TestTable1] WITH NOCHECK ADD CONSTRAINT [DF_TestTable1_TestColumn1] DEFAULT(GETDATE()) FOR [TestColumn1];";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        //Todo: This test must be enabled: [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public void CanAlterDefaultConstraintWithCurrentUtcDateAsDefault()
        {
            var expression = GeneratorTestHelper.GetAlterDefaultConstraintExpression();
            expression.DefaultValue = SystemMethods.CurrentUTCDateTime;

            string expected = "DECLARE @default sysname, @sql nvarchar(max);" + Environment.NewLine + Environment.NewLine +
            "-- get name of default constraint" + Environment.NewLine +
            "SELECT @default = name" + Environment.NewLine +
            "FROM sys.default_constraints" + Environment.NewLine +
            "WHERE parent_object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND type = 'D'" + Environment.NewLine +
            "AND parent_column_id = (" + Environment.NewLine +
            "SELECT column_id" + Environment.NewLine +
            "FROM sys.columns" + Environment.NewLine +
            "WHERE object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND name = 'TestColumn1'" + Environment.NewLine +
            ");" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to drop constraint as string and run it" + Environment.NewLine +
            "SET @sql = N'ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT ' + @default;" + Environment.NewLine +
            "EXEC sp_executesql @sql;" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to create new default constraint as string and run it" + Environment.NewLine +
            "ALTER TABLE [dbo].[TestTable1] WITH NOCHECK ADD CONSTRAINT [DF_TestTable1_TestColumn1] DEFAULT(GETUTCDATE()) FOR [TestColumn1];";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        //Todo: This test must be enabled: [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public void CanAlterDefaultConstraintWithNewGuidAsDefault()
        {
            var expression = GeneratorTestHelper.GetAlterDefaultConstraintExpression();
            expression.DefaultValue = SystemMethods.NewGuid;

            string expected = "DECLARE @default sysname, @sql nvarchar(max);" + Environment.NewLine + Environment.NewLine +
            "-- get name of default constraint" + Environment.NewLine +
            "SELECT @default = name" + Environment.NewLine +
            "FROM sys.default_constraints" + Environment.NewLine +
            "WHERE parent_object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND type = 'D'" + Environment.NewLine +
            "AND parent_column_id = (" + Environment.NewLine +
            "SELECT column_id" + Environment.NewLine +
            "FROM sys.columns" + Environment.NewLine +
            "WHERE object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND name = 'TestColumn1'" + Environment.NewLine +
            ");" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to drop constraint as string and run it" + Environment.NewLine +
            "SET @sql = N'ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT ' + @default;" + Environment.NewLine +
            "EXEC sp_executesql @sql;" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to create new default constraint as string and run it" + Environment.NewLine +
            "ALTER TABLE [dbo].[TestTable1] WITH NOCHECK ADD CONSTRAINT [DF_TestTable1_TestColumn1] DEFAULT(NEWID()) FOR [TestColumn1];";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        //Todo: This test must be enabled: [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public void CanAlterDefaultConstraintWithStringAsDefault()
        {
            var expression = GeneratorTestHelper.GetAlterDefaultConstraintExpression();
            expression.DefaultValue = "TestString";

            string expected = "DECLARE @default sysname, @sql nvarchar(max);" + Environment.NewLine + Environment.NewLine +
            "-- get name of default constraint" + Environment.NewLine +
            "SELECT @default = name" + Environment.NewLine +
            "FROM sys.default_constraints" + Environment.NewLine +
            "WHERE parent_object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND type = 'D'" + Environment.NewLine +
            "AND parent_column_id = (" + Environment.NewLine +
            "SELECT column_id" + Environment.NewLine +
            "FROM sys.columns" + Environment.NewLine +
            "WHERE object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND name = 'TestColumn1'" + Environment.NewLine +
            ");" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to drop constraint as string and run it" + Environment.NewLine +
            "SET @sql = N'ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT ' + @default;" + Environment.NewLine +
            "EXEC sp_executesql @sql;" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to create new default constraint as string and run it" + Environment.NewLine +
            "ALTER TABLE [dbo].[TestTable1] WITH NOCHECK ADD CONSTRAINT [DF_TestTable1_TestColumn1] DEFAULT('TestString') FOR [TestColumn1];";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        //Todo: This test must be enabled: [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public void CanAlterDefaultConstraintWithSqlFunctionAsDefault()
        {
            var expression = GeneratorTestHelper.GetAlterDefaultConstraintExpression();
            expression.DefaultValue = "MyTestFunction()";

            string expected = "DECLARE @default sysname, @sql nvarchar(max);" + Environment.NewLine + Environment.NewLine +
            "-- get name of default constraint" + Environment.NewLine +
            "SELECT @default = name" + Environment.NewLine +
            "FROM sys.default_constraints" + Environment.NewLine +
            "WHERE parent_object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND type = 'D'" + Environment.NewLine +
            "AND parent_column_id = (" + Environment.NewLine +
            "SELECT column_id" + Environment.NewLine +
            "FROM sys.columns" + Environment.NewLine +
            "WHERE object_id = object_id('[dbo].[TestTable1]')" + Environment.NewLine +
            "AND name = 'TestColumn1'" + Environment.NewLine +
            ");" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to drop constraint as string and run it" + Environment.NewLine +
            "SET @sql = N'ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT ' + @default;" + Environment.NewLine +
            "EXEC sp_executesql @sql;" + Environment.NewLine + Environment.NewLine +
            "-- create alter table command to create new default constraint as string and run it" + Environment.NewLine +
            "ALTER TABLE [dbo].[TestTable1] WITH NOCHECK ADD CONSTRAINT [DF_TestTable1_TestColumn1] DEFAULT(MyTestFunction()) FOR [TestColumn1];";

            var result = Generator.Generate(expression);
            result.ShouldBe(expected);
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateForeignKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";
            expression.ForeignKey.PrimaryTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_TestTable1_TestColumn1_TestTable2_TestColumn2] FOREIGN KEY ([TestColumn1]) REFERENCES [TestSchema].[TestTable2] ([TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateForeignKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateForeignKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_TestTable1_TestColumn1_TestTable2_TestColumn2] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateForeignKeyWithDifferentSchemas()
        {
            var expression = GeneratorTestHelper.GetCreateForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_TestTable1_TestColumn1_TestTable2_TestColumn2] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnForeignKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";
            expression.ForeignKey.PrimaryTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_TestTable1_TestColumn1_TestColumn3_TestTable2_TestColumn2_TestColumn4] FOREIGN KEY ([TestColumn1], [TestColumn3]) REFERENCES [TestSchema].[TestTable2] ([TestColumn2], [TestColumn4])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnForeignKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnForeignKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_TestTable1_TestColumn1_TestColumn3_TestTable2_TestColumn2_TestColumn4] FOREIGN KEY ([TestColumn1], [TestColumn3]) REFERENCES [dbo].[TestTable2] ([TestColumn2], [TestColumn4])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnForeignKeyWithDifferentSchemas()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_TestTable1_TestColumn1_TestColumn3_TestTable2_TestColumn2_TestColumn4] FOREIGN KEY ([TestColumn1], [TestColumn3]) REFERENCES [dbo].[TestTable2] ([TestColumn2], [TestColumn4])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnPrimaryKeyConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnPrimaryKeyExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [PK_TestTable1_TestColumn1_TestColumn2] PRIMARY KEY ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnPrimaryKeyConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [PK_TestTable1_TestColumn1_TestColumn2] PRIMARY KEY ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnUniqueConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnUniqueConstraintExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [UC_TestTable1_TestColumn1_TestColumn2] UNIQUE ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateMultiColumnUniqueConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateMultiColumnUniqueConstraintExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [UC_TestTable1_TestColumn1_TestColumn2] UNIQUE ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedForeignKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";
            expression.ForeignKey.PrimaryTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1]) REFERENCES [TestSchema].[TestTable2] ([TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedForeignKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedForeignKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedForeignKeyWithDifferentSchemas()
        {
            var expression = GeneratorTestHelper.GetCreateNamedForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedForeignKeyWithOnDeleteAndOnUpdateOptions()
        {
            var expression = GeneratorTestHelper.GetCreateNamedForeignKeyExpression();
            expression.ForeignKey.OnDelete = Rule.Cascade;
            expression.ForeignKey.OnUpdate = Rule.SetDefault;

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2]) ON DELETE CASCADE ON UPDATE SET DEFAULT");
        }

        [TestCase(Rule.SetDefault, "SET DEFAULT"), TestCase(Rule.SetNull, "SET NULL"), TestCase(Rule.Cascade, "CASCADE")]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedForeignKeyWithOnDeleteOptions(Rule rule, string output)
        {
            var expression = GeneratorTestHelper.GetCreateNamedForeignKeyExpression();
            expression.ForeignKey.OnDelete = rule;

            var result = Generator.Generate(expression);
            result.ShouldBe(string.Format("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2]) ON DELETE {0}", output));
        }

        [TestCase(Rule.SetDefault, "SET DEFAULT"), TestCase(Rule.SetNull, "SET NULL"), TestCase(Rule.Cascade, "CASCADE")]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedForeignKeyWithOnUpdateOptions(Rule rule, string output)
        {
            var expression = GeneratorTestHelper.GetCreateNamedForeignKeyExpression();
            expression.ForeignKey.OnUpdate = rule;

            var result = Generator.Generate(expression);
            result.ShouldBe(string.Format("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1]) REFERENCES [dbo].[TestTable2] ([TestColumn2]) ON UPDATE {0}", output));
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnForeignKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";
            expression.ForeignKey.PrimaryTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1], [TestColumn3]) REFERENCES [TestSchema].[TestTable2] ([TestColumn2], [TestColumn4])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnForeignKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnForeignKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1], [TestColumn3]) REFERENCES [dbo].[TestTable2] ([TestColumn2], [TestColumn4])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnForeignKeyWithDifferentSchemas()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [FK_Test] FOREIGN KEY ([TestColumn1], [TestColumn3]) REFERENCES [dbo].[TestTable2] ([TestColumn2], [TestColumn4])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnPrimaryKeyConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnPrimaryKeyExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [TESTPRIMARYKEY] PRIMARY KEY ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnPrimaryKeyConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [TESTPRIMARYKEY] PRIMARY KEY ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnUniqueConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnUniqueConstraintExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [TESTUNIQUECONSTRAINT] UNIQUE ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedMultiColumnUniqueConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedMultiColumnUniqueConstraintExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [TESTUNIQUECONSTRAINT] UNIQUE ([TestColumn1], [TestColumn2])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedPrimaryKeyConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedPrimaryKeyExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [TESTPRIMARYKEY] PRIMARY KEY ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedPrimaryKeyConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedPrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [TESTPRIMARYKEY] PRIMARY KEY ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedUniqueConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedUniqueConstraintExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [TESTUNIQUECONSTRAINT] UNIQUE ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateNamedUniqueConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateNamedUniqueConstraintExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [TESTUNIQUECONSTRAINT] UNIQUE ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreatePrimaryKeyConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreatePrimaryKeyExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [PK_TestTable1_TestColumn1] PRIMARY KEY ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreatePrimaryKeyConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreatePrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [PK_TestTable1_TestColumn1] PRIMARY KEY ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateUniqueConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetCreateUniqueConstraintExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] ADD CONSTRAINT [UC_TestTable1_TestColumn1] UNIQUE ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanCreateUniqueConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetCreateUniqueConstraintExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] ADD CONSTRAINT [UC_TestTable1_TestColumn1] UNIQUE ([TestColumn1])");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanDropForeignKeyWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteForeignKeyExpression();
            expression.ForeignKey.ForeignTableSchema = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] DROP CONSTRAINT [FK_Test]");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanDropForeignKeyWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteForeignKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT [FK_Test]");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanDropPrimaryKeyConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeletePrimaryKeyExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] DROP CONSTRAINT [TESTPRIMARYKEY]");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanDropPrimaryKeyConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeletePrimaryKeyExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT [TESTPRIMARYKEY]");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanDropUniqueConstraintWithCustomSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteUniqueConstraintExpression();
            expression.Constraint.SchemaName = "TestSchema";

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [TestSchema].[TestTable1] DROP CONSTRAINT [TESTUNIQUECONSTRAINT]");
        }

        [Test]
        [Category("SQLAnywhere"), Category("SQLAnywhere16"), Category("Generator"), Category("Constraint")]
        public override void CanDropUniqueConstraintWithDefaultSchema()
        {
            var expression = GeneratorTestHelper.GetDeleteUniqueConstraintExpression();

            var result = Generator.Generate(expression);
            result.ShouldBe("ALTER TABLE [dbo].[TestTable1] DROP CONSTRAINT [TESTUNIQUECONSTRAINT]");
        }
    }
}