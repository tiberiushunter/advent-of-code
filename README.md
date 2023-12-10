# :christmas_tree: Advent of Code

<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
![Project Maintenance][maintenance-shield]
[![MIT License][license-shield]][license-url]

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]

<!-- ABOUT -->
## About

A repository for my solutions to [Advent of Code][aoc]. This project is a C# console application using [.NET 8][.net] with the aim to solve all of the puzzles from 2015 to 2023.

Feel free to run through the solutions (*Note: Potential Spoilers* :see_no_evil: )

## Status

:star: - One Part
:star2: - Both Parts

| |01|02|03|04|05|06|07|08|09|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|
|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
|2015|:star2:|:star2:|:star2:||||||||||||||||||||||
|2016|||||||||||||||||||||||||
|2017|||||||||||||||||||||||||
|2018|||||||||||||||||||||||||
|2019|||||||||||||||||||||||||
|2020|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|||||||
|2021|:star2:|:star2:|||||||||||||||||||||||
|2022|||||||||||||||||||||||||
|2023|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:|:star2:||||||||||||||||||

<!-- GETTING STARTED -->
## Getting Started

### Setup

To run the code, ensure you have the [.NET 8 SDK][.net-sdk] or [Visual Studio 2022][visual-studio]

Then, if running without Visual Studio, from the root directory run `dotnet restore` to ensure you have the required NuGet packages installed. Alternatively run open the solution file to install the required packages.

### Session Cookie

Before starting the app for the first time, you'll want to grab your Advent of Code session cookie.

This will be used to fetch the puzzle input for each day directly from the site rather than needing to add it in yourself.

> :information_source: The app only downloads the input for a given day once and stores it in your Documents directory rather than getting the input from the Advent of Code servers every time.

To do this go to [Advent of Code][aoc] and get your session cookie using the Developer Tools.

Next, grab your Advent of Code session key. In Chrome this can be found under the Application tab in DevTools as seen below: 

![AoCSession](https://user-images.githubusercontent.com/10655940/109741093-4c5e7f80-7bc4-11eb-9e58-e463c64258a5.png)

You'll then need to create a copy of the `appsettings.template.json` file (located in the `AdventOfCode.Console` project) and name it `appsettings.json`.

Once you've copied your file, populate the `SessionToken` with the token retrieved.

### Running the app

To run the console app you can run the app in Visual Studio.

You'll then be presented with a Welcome Screen where you will be prompted to input a year and a day (or press Enter at both prompts to run all of the Advent of Code solutions) to see the results.

### Tests

After running the app for the first time and selecting `Run all Solutions`, the puzzle input will be downloaded for each day. Once this has been completed you'll be able to run the Solution tests to verify that the solutions work as expected.

<!-- LICENSE -->
## License

Distributed under the MIT License. See [LICENSE][license-url] for more information.

<!-- ACKNOWLEDGEMENTS -->
## Acknowledgements

* [rxaiver's GitHub Emoji Cheat Sheet][1]
* [Img Shields][2]
* [Choose an Open Source License][3]
* [othneildrew's Best README Template][4]

<!-- CONTACT -->
## Contact

Owner: Sam Welek

[![GitHub][github-shield]][github-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![X][x-shield]][x-url]

<a href="https://www.buymeacoffee.com/tiberiushunter" target="_blank"> <img src="https://cdn.buymeacoffee.com/buttons/default-yellow.png" alt="Buy Me A Coffee" height="41" width="174"></a>

Project Link: [GitHub][project-url]

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

<!-- Project Specific -->
[project-url]: https://github.com/tiberiushunter/advent-of-code/

[aoc]: https://adventofcode.com/
[.net]: https://dotnet.microsoft.com/
[.net-sdk]: https://dotnet.microsoft.com/download/
[visual-studio]: https://visualstudio.microsoft.com/vs/community/

[maintenance-shield]: https://img.shields.io/maintenance/yes/2023.svg?style=for-the-badge

[contributors-shield]: https://img.shields.io/github/contributors/tiberiushunter/advent-of-code.svg?style=for-the-badge
[contributors-url]: https://github.com/tiberiushunter/advent-of-code/graphs/contributors

[forks-shield]: https://img.shields.io/github/forks/tiberiushunter/advent-of-code.svg?style=for-the-badge
[forks-url]: https://github.com/tiberiushunter/advent-of-code/network/members

[stars-shield]: https://img.shields.io/github/stars/tiberiushunter/advent-of-code.svg?style=for-the-badge
[stars-url]: https://github.com/tiberiushunter/advent-of-code/stargazers

[issues-shield]: https://img.shields.io/github/issues/tiberiushunter/advent-of-code.svg?style=for-the-badge
[issues-url]: https://github.com/tiberiushunter/advent-of-code/issues

[license-shield]: https://img.shields.io/github/license/tiberiushunter/advent-of-code.svg?style=for-the-badge
[license-url]: https://github.com/tiberiushunter/advent-of-code/blob/main/LICENSE

<!-- Contact Specific -->
[github-shield]: https://img.shields.io/badge/-GitHub-black.svg?style=for-the-badge&logo=github&colorB=555
[github-url]: https://github.com/tiberiushunter

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/sam-welek

[x-shield]: https://img.shields.io/badge/-X-black.svg?style=for-the-badge&logo=x&colorB=555
[x-url]: https://x.com/samwelek

<!-- Acknowledgement Specific -->
[1]: https://gist.github.com/rxaviers/7360908
[2]: https://shields.io
[3]: https://choosealicense.com
[4]: https://github.com/othneildrew/Best-README-Template
