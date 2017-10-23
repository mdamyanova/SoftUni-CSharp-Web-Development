//Create users table

CREATE TABLE `blog`.`users` (
  `id` INT NULL AUTO_INCREMENT,
  `username` VARCHAR(15) NULL,
  `password` VARCHAR(50) NULL,
  `fullname` VARCHAR(30) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'This table will keep the information about our users';


//Create posts table

CREATE TABLE `blog`.`posts` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `author_id` INT NOT NULL,
  `title` VARCHAR(50) NULL,
  `content` TEXT NULL,
  `date` DATE NULL,
  PRIMARY KEY (`id`),
  INDEX `id_idx` (`author_id` ASC),
  CONSTRAINT `id`
    FOREIGN KEY (`author_id`)
    REFERENCES `blog`.`users` (`id`)
    ON DELETE RESTRICT
    ON UPDATE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COMMENT = 'This table will keep the information about our posts';