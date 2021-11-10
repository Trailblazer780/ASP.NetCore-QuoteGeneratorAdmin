-- Host: localhost:3306
-- Generation Time: Sep 25, 2016 at 10:48 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE TABLE IF NOT EXISTS `tblQuotes` (
  `author` varchar(100) NOT NULL,
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `quote` varchar(255) NOT NULL,
  `permalink` varchar(100),
  `image` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=7;


INSERT INTO `tblQuotes` (`author`, `id`, `quote`, `permalink`, `image`) VALUES
('Bill Sempf',44,'QA Engineer walks into a bar. Orders a beer. Orders 0 beers. Orders 999999999 beers. Orders a lizard. Orders -1 beers. Orders a sfdeljknesv.','http://quotes.stormconsultancy.co.uk/quotes/44', 'Image1.jpg'),
('Phil Karlton',43,'There are only two hard things in Computer Science: cache invalidation, naming things and off-by-one errors.','http://quotes.stormconsultancy.co.uk/quotes/43', 'Image2.jpg'),
('Jeff Atwood',42,'In software, we rarely have meaningful requirements. Even if we do, the only measure of success that matters is whether our solution solves the customer’s shifting idea of what their problem is.','http://quotes.stormconsultancy.co.uk/quotes/42','Image3.jpg'),
('Robert Sewell',41,'If Java had true garbage collection, most programs would delete themselves upon execution.','http://quotes.stormconsultancy.co.uk/quotes/41', 'Image4.jpg'),
('Bjarne Stroustrup',39,'In C++ it’s harder to shoot yourself in the foot, but when you do, you blow off your whole leg.','http://quotes.stormconsultancy.co.uk/quotes/39', 'Image5.jpg'),
('Alan Kay',38,'Most software today is very much like an Egyptian pyramid with millions of bricks piled on top of each other, with no structural integrity, but just done by brute force and thousands of slaves.','http://quotes.stormconsultancy.co.uk/quotes/38', 'Image6.jpg'), 
('Larry DeLuca',37,'I’ve noticed lately that the paranoid fear of computers becoming intelligent and taking over the world has almost entirely disappeared from the common culture.  Near as I can tell, this coincides with the release of MS-DOS.','http://quotes.stormconsultancy.co.uk/quotes/37', 'Image7.jpg'),
('Mark Gibbs',36,'No matter how slick the demo is in rehearsal, when you do it in front of a live audience, the probability of a flawless presentation is inversely proportional to the number of people watching, raised to the power of the amount of money involved.','http://quotes.stormconsultancy.co.uk/quotes/36', 'Image8.jpg'),
('Henry Petroski',35,'The most amazing achievement of the computer software industry is its continuing cancellation of the steady and staggering gains made by the computer hardware industry.','http://quotes.stormconsultancy.co.uk/quotes/35', 'Image9.jpg'),
('Jeremy S. Anderson',34,'There are two major products that come out of Berkeley: LSD and UNIX.  We don’t believe this to be a coincidence.','http://quotes.stormconsultancy.co.uk/quotes/34', 'Image10.jpg'),
('Jamie Zawinski',32,'Linux is only free if your time has no value.','http://quotes.stormconsultancy.co.uk/quotes/32', 'Image11.jpg'),
('Richard Moore',30,'The difference between theory and practice is that in theory, there is no difference between theory and practice.','http://quotes.stormconsultancy.co.uk/quotes/30', 'Image12.jpg'),
('Bjarne Stroustrup',28,'There are only two kinds of programming languages: those people always bitch about and those nobody uses.','http://quotes.stormconsultancy.co.uk/quotes/28', 'Image13.jpg'),
('Donald Knuth',27,'Beware of bugs in the above code; I have only proved it correct, not tried it. ','http://quotes.stormconsultancy.co.uk/quotes/27', 'Image13.jpg'),
('Tom Van Vleck',26,'We know about as much about software quality problems as they knew about the Black Plague in the 1600s. We’ve seen the victims’ agonies and helped burn the corpses. We don’t know what causes it; we don’t really know if there is only one disease. We just suffer — and keep pouring our sewage into our water supply.','http://quotes.stormconsultancy.co.uk/quotes/26', 'Image14.jpg'),
('N.J. Rubenking',25,'Writing the first 90 percent of a computer program takes 90 percent of the time. The remaining ten percent also takes 90 percent of the time and the final touches also take 90 percent of the time.','http://quotes.stormconsultancy.co.uk/quotes/25', 'Image15.jpg'),
('C. A. R. Hoare',24,'There are two ways of constructing a software design; one way is to make it so simple that there are obviously no deficiencies, and the other way is to make it so complicated that there are no obvious deficiencies. The first method is far more difficult.','http://quotes.stormconsultancy.co.uk/quotes/24', 'Image16.jpg'),
('James O. Coplien',23,'You should name a variable using the same care with which you name a first-born child.','http://quotes.stormconsultancy.co.uk/quotes/23', 'Image17.jpg'),
('Fred Brooks',22,'Einstein argued that there must be simplified explanations of nature, because God is not capricious or arbitrary. No such faith comforts the software engineer.','http://quotes.stormconsultancy.co.uk/quotes/22', 'Image18.jpg'),
('Douglas Adams',19,'I love deadlines. I like the whooshing sound they make as they fly by.','http://quotes.stormconsultancy.co.uk/quotes/19', 'Image19.jpg'),
('Keith Bostic',18,'Perl – The only language that looks the same before and after RSA encryption.','http://quotes.stormconsultancy.co.uk/quotes/18', 'Image20.jpg'),
('Albert Einstein',17,'Two things are infinite: the universe and human stupidity; and I’m not sure about the universe.','http://quotes.stormconsultancy.co.uk/quotes/17','Image21.jpg'),
('Yogi Berra',16,'In theory, theory and practice are the same. In practice, they’re not.','http://quotes.stormconsultancy.co.uk/quotes/16','Image22.jpg'),
('E. W. Dijkstra',15,'It is practically impossible to teach good programming style to students that have had prior exposure to BASIC. As potential programmers, they are mentally mutilated beyond hope of regeneration.','http://quotes.stormconsultancy.co.uk/quotes/15','Image23.jpg'),
('E. W. Dijkstra',14,'If debugging is the process of removing software bugs, then programming must be the process of putting them in.','http://quotes.stormconsultancy.co.uk/quotes/14','Image24.jpg'),
('Mitch Ratcliffe',13,'A computer lets you make more mistakes faster than any other invention in human history, with the possible exceptions of handguns and tequila.','http://quotes.stormconsultancy.co.uk/quotes/13','Image25.jpg'),
('Bjarne Stroustrup',12,'I have always wished for my computer to be as easy to use as my telephone; my wish has come true because I can no longer figure out how to use my telephone.','http://quotes.stormconsultancy.co.uk/quotes/12','Image26.jpg'),
('Ovidiu Platon',11,'I don’t care if it works on your machine! We are not shipping your machine!','http://quotes.stormconsultancy.co.uk/quotes/11','Image27.jpg'),
('Rich Cook',10,'Programming today is a race between software engineers striving to build bigger and better idiot-proof programs, and the Universe trying to produce bigger and better idiots. So far, the Universe is winning.','http://quotes.stormconsultancy.co.uk/quotes/10','Image28.jpg'),
('Rick Osborne',9,'Always code as if the guy who ends up maintaining your code will be a violent psychopath who knows where you live.','http://quotes.stormconsultancy.co.uk/quotes/9','Image29.jpg'),
('Charles Babbage',8,'On two occasions I have been asked, ‘Pray, Mr. Babbage, if you put into the machine wrong figures, will the right answers come out?’ I am not able rightly to apprehend the kind of confusion of ideas that could provoke such a question.”','http://quotes.stormconsultancy.co.uk/quotes/8','Image30.jpg'),
('Jon Ribbens',7,'PHP is a minor evil perpetrated and created by incompetent amateurs, whereas Perl is a great and insidious evil, perpetrated by skilled but perverted professionals.','http://quotes.stormconsultancy.co.uk/quotes/7','Image31.jpg'),
('Bill Gates',6,'Measuring programming progress by lines of code is like measuring aircraft building progress by weight.','http://quotes.stormconsultancy.co.uk/quotes/6','Image32.jpg'),
('Brian Kernighan',5,'Debugging is twice as hard as writing the code in the first place. Therefore, if you write the code as cleverly as possible, you are, by definition, not smart enough to debug it.','http://quotes.stormconsultancy.co.uk/quotes/5','Image33.jpg'),
('Jamie Zawinski',4,'Some people, when confronted with a problem, think “I know, I’ll use regular expressions.” Now they have two problems.','http://quotes.stormconsultancy.co.uk/quotes/4','Image34.jpg'),
('Hofstadter’s Law',3,'It always takes longer than you expect, even when you take into account Hofstadter’s Law.','http://quotes.stormconsultancy.co.uk/quotes/3','Image35.jpg'),
('Edward V Berard',2,'Walking on water and developing software from a specification are easy if both are frozen.','http://quotes.stormconsultancy.co.uk/quotes/2','Image36.jpg'),
('C. A. R. Hoare',1,'We should forget about small efficiencies, say about 97% of the time: premature optimization is the root of all evil.','http://quotes.stormconsultancy.co.uk/quotes/1','Image37.jpg');