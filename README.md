# SauceDemo Login Test Automation

## Project Overview

This project automates the login form tests for the SauceDemo website. It uses SpecFlow with MSTest, Selenium WebDriver, and supports execution across multiple browsers.

## UC-1: Empty Credentials
- Enter any credentials
- Clear both fields
- Verify "Username is required" message

## UC-2: Missing Password
- Enter username
- Clear password
- Verify "Password is required" message

## UC-3: Valid Credentials
- Enter valid credentials
- Verify navigation to the Swag Labs dashboard

## Key Features:
- Cross-browser testing (Chrome, Edge)
- Parallel execution
- Fluent Assertions
- BDD approach with SpecFlow
