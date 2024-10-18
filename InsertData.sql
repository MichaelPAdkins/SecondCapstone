
-- Inserting Data into UserProfile
set identity_insert [UserProfile] on
INSERT INTO UserProfile (Id, DisplayName, FirstName, LastName, Email)
VALUES 
(1, 'MPaul', 'Michael', 'Paul', 'mostexalted@mostexalted.com');
set identity_insert [UserProfile] off

-- Inserting Data into Tags
set identity_insert [Tags] on
INSERT INTO Tags (Id, Name)
VALUES 
(1, 'bicycles'), 
(2, 'cars'),
(3, 'night life'),
(4, 'dog'),
(5, 'cat'),
(6, 'rain'),
(7, 'John'),
(8, 'Emily'),
(9, 'Mike'),
(10, 'Sarah'),
(11, 'weather'),
(12, 'photography'),
(13, 'sunset'),
(14, 'ocean'),
(15, 'mountains'),
(16, 'city'),
(17, 'street'),
(18, 'nature'),
(19, 'portrait'),
(20, 'family'),
(21, 'friends'),
(22, 'Jessica'),
(23, 'David'),
(24, 'James'),
(25, 'Laura'),
(26, 'Jennifer'),
(27, 'Chris'),
(28, 'Anna'),
(29, 'Daniel'),
(30, 'Paul'),
(31, 'Linda'),
(32, 'garden'),
(33, 'flowers'),
(34, 'trees'),
(35, 'beach'),
(36, 'park'),
(37, 'sunrise'),
(38, 'waterfall'),
(39, 'clouds'),
(40, 'forest'),
(41, 'snow'),
(42, 'travel'),
(43, 'vacation'),
(44, 'camping'),
(45, 'hiking'),
(46, 'fishing'),
(47, 'Jessica'),
(48, 'Matthew'),
(49, 'Amy'),
(50, 'Steven'),
(51, 'Taylor'),
(52, 'Aaron'),
(53, 'Robert'),
(54, 'Julia'),
(55, 'Rachel'),
(56, 'Brandon'),
(57, 'Joshua'),
(58, 'Victoria'),
(59, 'Clara'),
(60, 'Ethan'),
(61, 'Samantha'),
(62, 'Kevin'),
(63, 'Amanda'),
(64, 'Andrew'),
(65, 'Isabella'),
(66, 'Nathan'),
(67, 'Zoey'),
(68, 'bikes'),
(69, 'cars'),
(70, 'motorcycles'),
(71, 'trains'),
(72, 'planes'),
(73, 'skyscrapers'),
(74, 'bridges'),
(75, 'concert'),
(76, 'restaurant'),
(77, 'nightclub'),
(78, 'bar'),
(79, 'coffee shop'),
(80, 'school'),
(81, 'sports'),
(82, 'tennis'),
(83, 'soccer'),
(84, 'basketball'),
(85, 'football'),
(86, 'gym'),
(87, 'running'),
(88, 'street photography'),
(89, 'rooftop'),
(90, 'downtown'),
(91, 'warehouse'),
(92, 'market'),
(93, 'train station'),
(94, 'airport'),
(95, 'subway'),
(96, 'farm'),
(97, 'animals'),
(98, 'insects'),
(99, 'rainy day'),
(100, 'fog');
set identity_insert [Tags] off


-- Inserting Data into Camera
set identity_insert [Camera] on
INSERT INTO Camera (Id, Name)
VALUES 
(1, 'Canon 20D'),
(2, 'Fuji XPro2'),
(3, 'Lomo LC-A'),
(4, 'Leica M6'),
(5, 'Sony A6000'),
(6, 'Fuji X100'),
(7, 'Olympus OM2N');
set identity_insert [Camera] off


-- Inserting Data into Locations
set identity_insert [Locations] on
INSERT INTO Locations (Id, Name)
VALUES 
(1, 'Huntington'),
(2, 'West Virginia'),
(3, 'California'),
(4, 'Los Angeles'),
(5, 'San Francisco'),
(6, 'Indianapolis'),
(7, 'Indiana'),
(8, 'bar'),
(9, 'nightclub'),
(10, 'streetshot'),
(11, 'bedroom'),
(12, 'hotel room'),
(13, 'circus'),
(14, 'operating room'),
(15, 'jail cell'),
(16, 'beach'),
(17, 'forest'),
(18, 'mountain'),
(19, 'park'),
(20, 'desert'),
(21, 'amusement park'),
(22, 'museum'),
(23, 'library'),
(24, 'office'),
(25, 'warehouse'),
(26, 'farm'),
(27, 'lake'),
(28, 'shopping mall'),
(29, 'gas station'),
(30, 'train station'),
(31, 'subway'),
(32, 'airplane'),
(33, 'rooftop'),
(34, 'backyard'),
(35, 'kitchen');
set identity_insert [Locations] off


-- Inserting Data into Entry
set identity_insert [Entry] on
INSERT INTO Entry (Id, FileName, CaptureDate, FileSize, Resolution, PhysicalBackUps, CameraId, UserId)
VALUES 
(1, '20221013dsc7233.jpg', '10/13/2022', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 1, 1),
(2, '20190507raw1234.jpg', '05/07/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2, negative sleeve 5234', 2, 1),
(3, '20180311orf4321.jpg', '03/11/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 9876', 3, 1),
(4, '20180714dsc8934.jpg', '07/14/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 4, 1),
(5, '20161209raw1234.jpg', '12/09/2016', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2, negative sleeve 3421', 5, 1),
(6, '20200123orf4567.jpg', '01/23/2020', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3', 6, 1),
(7, '20191105dsc9821.jpg', '11/05/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 1, 1),
(8, '20170919raw8723.jpg', '09/19/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1, negative sleeve 6543', 2, 1),
(9, '20180522orf1123.jpg', '05/22/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 3, 1),
(10, '20170803dsc2234.jpg', '08/03/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 7312', 4, 1),
(11, '20191129raw3421.jpg', '11/29/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 5, 1),
(12, '20170515orf4325.jpg', '05/15/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 6, 1),
(13, '20210311dsc8542.jpg', '03/11/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 1, 1),
(14, '20161225raw5234.jpg', '12/25/2016', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 2143', 2, 1),
(15, '20181022orf7345.jpg', '10/22/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 3, 1),
(16, '20210914dsc9341.jpg', '09/14/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 4, 1),
(17, '20200817raw9824.jpg', '08/17/2020', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2, negative sleeve 6541', 5, 1),
(18, '20171229orf4234.jpg', '12/29/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3', 6, 1),
(19, '20160611dsc8472.jpg', '06/11/2016', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 1, 1),
(20, '20220309raw7435.jpg', '03/09/2022', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1, negative sleeve 8721', 2, 1),
(21, '20170927orf5234.jpg', '09/27/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 3, 1),
(22, '20210604dsc7431.jpg', '06/04/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 6234', 4, 1),
(23, '20181110raw3214.jpg', '11/10/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 5, 1),
(24, '20170422orf9234.jpg', '04/22/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 6, 1),
(25, '20191217dsc8324.jpg', '12/17/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2, negative sleeve 5213', 1, 1),
(26, '20210505raw5211.jpg', '05/05/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3', 2, 1),
(27, '20161113orf4312.jpg', '11/13/2016', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 3, 1),
(28, '20200823dsc5234.jpg', '08/23/2020', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1, negative sleeve 8765', 4, 1),
(29, '20220218raw7632.jpg', '02/18/2022', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 5, 1),
(30, '20210930orf9854.jpg', '09/30/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3', 6, 1),
(31, '20180525dsc6732.jpg', '05/25/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 1, 1),
(32, '20171016raw9832.jpg', '10/16/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1, negative sleeve 2178', 2, 1),
(33, '20210323orf3124.jpg', '03/23/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 3, 1),
(34, '20190105dsc9345.jpg', '01/05/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3', 4, 1),
(35, '20220711raw4323.jpg', '07/11/2022', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4, negative sleeve 9324', 5, 1),
(36, '20201217orf3432.jpg', '12/17/2020', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 6, 1),
(37, '20190614dsc5432.jpg', '06/14/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 1, 1),
(38, '20210430raw8321.jpg', '04/30/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 1342', 2, 1),
(39, '20210709orf5123.jpg', '07/09/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 3, 1),
(40, '20190823dsc1234.jpg', '08/23/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 4, 1),
(41, '20220614raw6543.jpg', '06/14/2022', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 5, 1),
(42, '20210519orf9876.jpg', '05/19/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3', 6, 1),
(43, '20170323dsc1987.jpg', '03/23/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4, negative sleeve 1234', 1, 1),
(44, '20181118raw7345.jpg', '11/18/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 2, 1),
(45, '20191212orf3487.jpg', '12/12/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 3, 1),
(46, '20201030dsc8123.jpg', '10/30/2020', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 6345', 4, 1),
(47, '20170914raw5423.jpg', '09/14/2017', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 5, 1),
(48, '20180612orf2134.jpg', '06/12/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 6, 1),
(49, '20220203dsc1234.jpg', '02/03/2022', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 2', 1, 1),
(50, '20180723raw7654.jpg', '07/23/2018', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 3, negative sleeve 3456', 2, 1),
(51, '20191017orf7432.jpg', '10/17/2019', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 4', 3, 1),
(52, '20210907dsc3452.jpg', '09/07/2021', '19.92 MB', '6192 x 8526', 'Master 1, External Drive 1', 4, 1);
set identity_insert [Entry] off


-- Inserting Data into EntryTags
set identity_insert [EntryTags] on
INSERT INTO EntryTags (Id, EntryId, TagId)
VALUES 
-- Entry 1
(1, 1, 1),  -- 'bicycles'
(2, 1, 4),  -- 'dog'
-- Entry 2
(3, 2, 3),  -- 'night life'
(4, 2, 7),  -- 'John'
-- Entry 3
(5, 3, 2),  -- 'cars'
(6, 3, 8),  -- 'Emily'
-- Entry 4
(7, 4, 6),  -- 'rain'
(8, 4, 9),  -- 'Mike'
-- Entry 5
(9, 5, 5),  -- 'cat'
(10, 5, 11), -- 'weather'
-- Entry 6
(11, 6, 1),  -- 'bicycles'
(12, 6, 10), -- 'Sarah'
-- Entry 7
(13, 7, 3),  -- 'night life'
(14, 7, 2),  -- 'cars'
-- Entry 8
(15, 8, 4),  -- 'dog'
(16, 8, 6),  -- 'rain'
-- Entry 9
(17, 9, 7),  -- 'John'
(18, 9, 9),  -- 'Mike'
-- Entry 10
(19, 10, 8),  -- 'Emily'
(20, 10, 11), -- 'weather'
-- Entry 11
(21, 11, 1),  -- 'bicycles'
(22, 11, 2),  -- 'cars'
-- Entry 12
(23, 12, 4),  -- 'dog'
(24, 12, 5),  -- 'cat'
-- Entry 13
(25, 13, 6),  -- 'rain'
(26, 13, 8),  -- 'Emily'
-- Entry 14
(27, 14, 9),  -- 'Mike'
(28, 14, 3),  -- 'night life'
-- Entry 15
(29, 15, 7),  -- 'John'
(30, 15, 11), -- 'weather'
-- Entry 16
(31, 16, 2),  -- 'cars'
(32, 16, 5),  -- 'cat'
-- Entry 17
(33, 17, 6),  -- 'rain'
(34, 17, 4),  -- 'dog'
-- Entry 18
(35, 18, 9),  -- 'Mike'
(36, 18, 10), -- 'Sarah'
-- Entry 19
(37, 19, 1),  -- 'bicycles'
(38, 19, 7),  -- 'John'
-- Entry 20
(39, 20, 8),  -- 'Emily'
(40, 20, 11), -- 'weather'
-- Entry 21
(41, 21, 2),  -- 'cars'
(42, 21, 3),  -- 'night life'
-- Entry 22
(43, 22, 5),  -- 'cat'
(44, 22, 6),  -- 'rain'
-- Entry 23
(45, 23, 9),  -- 'Mike'
(46, 23, 4),  -- 'dog'
-- Entry 24
(47, 24, 10), -- 'Sarah'
(48, 24, 8),  -- 'Emily'
-- Entry 25
(49, 25, 11), -- 'weather'
(50, 25, 7),  -- 'John'
-- Entry 26
(51, 26, 1),  -- 'bicycles'
(52, 26, 3),  -- 'night life'
-- Entry 27
(53, 27, 2),  -- 'cars'
(54, 27, 6),  -- 'rain'
-- Entry 28
(55, 28, 5),  -- 'cat'
(56, 28, 4),  -- 'dog'
-- Entry 29
(57, 29, 9),  -- 'Mike'
(58, 29, 8),  -- 'Emily'
-- Entry 30
(59, 30, 7),  -- 'John'
(60, 30, 10), -- 'Sarah'
-- Entry 31
(61, 31, 1),  -- 'bicycles'
(62, 31, 2),  -- 'cars'
-- Entry 32
(63, 32, 4),  -- 'dog'
(64, 32, 6),  -- 'rain'
-- Entry 33
(65, 33, 3),  -- 'night life'
(66, 33, 7),  -- 'John'
-- Entry 34
(67, 34, 5),  -- 'cat'
(68, 34, 11), -- 'weather'
-- Entry 35
(69, 35, 8),  -- 'Emily'
(70, 35, 9),  -- 'Mike'
-- Entry 36
(71, 36, 10), -- 'Sarah'
(72, 36, 11), -- 'weather'
-- Entry 37
(73, 37, 1),  -- 'bicycles'
(74, 37, 3),  -- 'night life'
-- Entry 38
(75, 38, 2),  -- 'cars'
(76, 38, 5),  -- 'cat'
-- Entry 39
(77, 39, 6),  -- 'rain'
(78, 39, 8),  -- 'Emily'
-- Entry 40
(79, 40, 4),  -- 'dog'
(80, 40, 9),  -- 'Mike'
-- Entry 41
(81, 41, 7),  -- 'John'
(82, 41, 10), -- 'Sarah'
-- Entry 42
(83, 42, 2),  -- 'cars'
(84, 42, 3),  -- 'night life'
-- Entry 43
(85, 43, 5),  -- 'cat'
(86, 43, 6),  -- 'rain'
-- Entry 44
(87, 44, 8),  -- 'Emily'
(88, 44, 11), -- 'weather'
-- Entry 45
(89, 45, 9),  -- 'Mike'
(90, 45, 1),  -- 'bicycles'
-- Entry 46
(91, 46, 4),  -- 'dog'
(92, 46, 3),  -- 'night life'
-- Entry 47
(93, 47, 7),  -- 'John'
(94, 47, 2),  -- 'cars'
-- Entry 48
(95, 48, 6),  -- 'rain'
(96, 48, 9),  -- 'Mike'
-- Entry 49
(97, 49, 5),  -- 'cat'
(98, 49, 8),  -- 'Emily'
-- Entry 50
(99, 50, 11), -- 'weather'
(100, 50, 10), -- 'Sarah'
-- Entry 51
(101, 51, 1), -- 'bicycles'
(102, 51, 4), -- 'dog'
-- Entry 52
(103, 52, 6), -- 'rain'
(104, 52, 8); -- 'Emily'
set identity_insert [EntryTags] off


-- Inserting Data into EntryLocations
set identity_insert [EntryLocations] on
INSERT INTO EntryLocations (Id, EntryId, LocationsId)
VALUES
-- Entry 1
(1, 1, 3),  -- California (city/state)
(2, 1, 10), -- streetshot (general)
-- Entry 2
(3, 2, 4),  -- Los Angeles (city/state)
(4, 2, 8),  -- bar (general)
-- Entry 3
(5, 3, 5),  -- San Francisco (city/state)
(6, 3, 12), -- hotel room (general)
-- Entry 4
(7, 4, 6),  -- Indianapolis (city/state)
(8, 4, 16), -- beach (general)
-- Entry 5
(9, 5, 7),  -- Indiana (city/state)
(10, 5, 17), -- forest (general)
-- Entry 6
(11, 6, 3), -- California (city/state)
(12, 6, 18), -- mountain (general)
-- Entry 7
(13, 7, 5), -- San Francisco (city/state)
(14, 7, 9), -- nightclub (general)
-- Entry 8
(15, 8, 4), -- Los Angeles (city/state)
(16, 8, 13), -- circus (general)
-- Entry 9
(17, 9, 6), -- Indianapolis (city/state)
(18, 9, 20), -- desert (general)
-- Entry 10
(19, 10, 7), -- Indiana (city/state)
(20, 10, 19), -- park (general)
-- Entry 11
(21, 11, 3), -- California (city/state)
(22, 11, 21), -- amusement park (general)
-- Entry 12
(23, 12, 2), -- West Virginia (city/state)
(24, 12, 11), -- bedroom (general)
-- Entry 13
(25, 13, 4), -- Los Angeles (city/state)
(26, 13, 22), -- museum (general)
-- Entry 14
(27, 14, 6), -- Indianapolis (city/state)
(28, 14, 14), -- operating room (general)
-- Entry 15
(29, 15, 5), -- San Francisco (city/state)
(30, 15, 23), -- library (general)
-- Entry 16
(31, 16, 7), -- Indiana (city/state)
(32, 16, 24), -- office (general)
-- Entry 17
(33, 17, 3), -- California (city/state)
(34, 17, 25), -- warehouse (general)
-- Entry 18
(35, 18, 2), -- West Virginia (city/state)
(36, 18, 9), -- nightclub (general)
-- Entry 19
(37, 19, 6), -- Indianapolis (city/state)
(38, 19, 26), -- farm (general)
-- Entry 20
(39, 20, 7), -- Indiana (city/state)
(40, 20, 16), -- beach (general)
-- Entry 21
(41, 21, 5), -- San Francisco (city/state)
(42, 21, 27), -- lake (general)
-- Entry 22
(43, 22, 4), -- Los Angeles (city/state)
(44, 22, 8), -- bar (general)
-- Entry 23
(45, 23, 3), -- California (city/state)
(46, 23, 10), -- streetshot (general)
-- Entry 24
(47, 24, 6), -- Indianapolis (city/state)
(48, 24, 19), -- park (general)
-- Entry 25
(49, 25, 2), -- West Virginia (city/state)
(50, 25, 12), -- hotel room (general)
-- Entry 26
(51, 26, 7), -- Indiana (city/state)
(52, 26, 11), -- bedroom (general)
-- Entry 27
(53, 27, 5), -- San Francisco (city/state)
(54, 27, 28), -- shopping mall (general)
-- Entry 28
(55, 28, 4), -- Los Angeles (city/state)
(56, 28, 29), -- gas station (general)
-- Entry 29
(57, 29, 6), -- Indianapolis (city/state)
(58, 29, 9), -- nightclub (general)
-- Entry 30
(59, 30, 7), -- Indiana (city/state)
(60, 30, 30), -- train station (general)
-- Entry 31
(61, 31, 3), -- California (city/state)
(62, 31, 8), -- bar (general)
-- Entry 32
(63, 32, 5), -- San Francisco (city/state)
(64, 32, 19), -- park (general)
-- Entry 33
(65, 33, 2), -- West Virginia (city/state)
(66, 33, 10), -- streetshot (general)
-- Entry 34
(67, 34, 4), -- Los Angeles (city/state)
(68, 34, 31), -- subway (general)
-- Entry 35
(69, 35, 7), -- Indiana (city/state)
(70, 35, 32), -- airplane (general)
-- Entry 36
(71, 36, 3), -- California (city/state)
(72, 36, 16), -- beach (general)
-- Entry 37
(73, 37, 6), -- Indianapolis (city/state)
(74, 37, 12), -- hotel room (general)
-- Entry 38
(75, 38, 5), -- San Francisco (city/state)
(76, 38, 33), -- rooftop (general)
-- Entry 39
(77, 39, 4), -- Los Angeles (city/state)
(78, 39, 11), -- bedroom (general)
-- Entry 40
(79, 40, 7), -- Indiana (city/state)
(80, 40, 34), -- backyard (general)
-- Entry 41
(81, 41, 6), -- Indianapolis (city/state)
(82, 41, 19), -- park (general)
-- Entry 42
(83, 42, 3), -- California (city/state)
(84, 42, 35), -- kitchen (general)
-- Entry 43
(85, 43, 2), -- West Virginia (city/state)
(86, 43, 9), -- nightclub (general)
-- Entry 44
(87, 44, 5), -- San Francisco (city/state)
(88, 44, 26), -- farm (general)
-- Entry 45
(89, 45, 7), -- Indiana (city/state)
(90, 45, 14), -- operating room (general)
-- Entry 46
(91, 46, 4), -- Los Angeles (city/state)
(92, 46, 16), -- beach (general)
-- Entry 47
(93, 47, 6), -- Indianapolis (city/state)
(94, 47, 10), -- streetshot (general)
-- Entry 48
(95, 48, 3), -- California (city/state)
(96, 48, 8), -- bar (general)
-- Entry 49
(97, 49, 2), -- West Virginia (city/state)
(98, 49, 19), -- park (general)
-- Entry 50
(99, 50, 7), -- Indiana (city/state)
(100, 50, 12), -- hotel room (general)
-- Entry 51
(101, 51, 5), -- San Francisco (city/state)
(102, 51, 33), -- rooftop (general)
-- Entry 52
(103, 52, 4), -- Los Angeles (city/state)
(104, 52, 9); -- nightclub (general)
set identity_insert [EntryLocations] off

