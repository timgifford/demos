package com.giffordconsulting;

import cucumber.api.junit.Cucumber;
import org.junit.runner.RunWith;

@RunWith(Cucumber.class)
@Cucumber.Options(tags = {"~@WIP"},format = {"html:target/cucumber-html-report", "json-pretty:target/cucumber-json-report.json"})
public class RunCukesTest {
}
