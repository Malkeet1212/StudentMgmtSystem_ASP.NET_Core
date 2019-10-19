SET IDENTITY_INSERT [dbo].[Course] ON
INSERT INTO [dbo].[Course] ([Id], [CourseName], [Credits]) VALUES (1, N'Java Programming', 40)
INSERT INTO [dbo].[Course] ([Id], [CourseName], [Credits]) VALUES (2, N'C# Programming', 40)
INSERT INTO [dbo].[Course] ([Id], [CourseName], [Credits]) VALUES (1002, N'Networking and OS', 60)
INSERT INTO [dbo].[Course] ([Id], [CourseName], [Credits]) VALUES (1003, N'Mobile applications ', 60)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT INTO [dbo].[Student] ([Id], [StudentName], [ContactNumber]) VALUES (1, N'Ryan Watson', N'02198876543')
INSERT INTO [dbo].[Student] ([Id], [StudentName], [ContactNumber]) VALUES (2, N'Francis Hardy', N'02134567890')
INSERT INTO [dbo].[Student] ([Id], [StudentName], [ContactNumber]) VALUES (1002, N'David Wilkinson', N'02134567899')
SET IDENTITY_INSERT [dbo].[Student] OFF
SET IDENTITY_INSERT [dbo].[Enrollment] ON
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [StudentId], [Semester]) VALUES (1002, 1, 1, 0)
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [StudentId], [Semester]) VALUES (1003, 2, 1, 0)
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [StudentId], [Semester]) VALUES (1004, 1003, 2, 1)
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [StudentId], [Semester]) VALUES (1005, 1002, 1002, 0)
INSERT INTO [dbo].[Enrollment] ([Id], [CourseId], [StudentId], [Semester]) VALUES (1006, 1003, 1, 1)
SET IDENTITY_INSERT [dbo].[Enrollment] OFF
SET IDENTITY_INSERT [dbo].[Result] ON
INSERT INTO [dbo].[Result] ([Id], [CourseId], [StudentId], [Grade]) VALUES (3, 1, 1, 0)
INSERT INTO [dbo].[Result] ([Id], [CourseId], [StudentId], [Grade]) VALUES (4, 2, 2, 0)
INSERT INTO [dbo].[Result] ([Id], [CourseId], [StudentId], [Grade]) VALUES (5, 1002, 1002, 0)
INSERT INTO [dbo].[Result] ([Id], [CourseId], [StudentId], [Grade]) VALUES (6, 1003, 1, 1)
SET IDENTITY_INSERT [dbo].[Result] OFF

