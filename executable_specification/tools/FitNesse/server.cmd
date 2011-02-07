@echo off
title FitNesse server
set fithome=%~dp0
set test_dir=%fithome%..\..\FitnesseTests
set opts= -o -e 0
set opts=%opts% -d %test_dir%
set opts=%opts% -p 8081
echo %opts%
java -jar fitnesse.jar %opts%
