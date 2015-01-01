package com.giffordconsulting.sayso;

import com.giffordconsulting.sayso.Gender;
import com.giffordconsulting.sayso.ScenarioContext;
import com.giffordconsulting.sayso.Subscriber;
import com.giffordconsulting.sayso.SubscriberBroadcast;
import cucumber.api.DataTable;
import cucumber.api.PendingException;
import cucumber.api.Transform;
import cucumber.api.java.en.*;
import cucumber.api.junit.Cucumber;

import java.util.List;

import static org.junit.Assert.assertEquals;

public class SendAdvertisementSteps {
    private final SubscriberBroadcast subscriberBroadcast = new SubscriberBroadcast();
    private ScenarioContext context;
    private List<Subscriber> receivingSubscribers;

    public SendAdvertisementSteps(ScenarioContext context) {
        this.context = context;
    }

    @Given("^Sayso margin is (\\d+) cents$")
    public void Sayso_margin_is_cents(int margin) throws Throwable {
        context.setMargin(margin);
    }

    @Given("^Subscribers$")
    public void Subscribers(List<Subscriber> subscribers) throws Throwable {
        context.setSubscribers(subscribers);
    }

    @Given("^Advertiser price is (\\d+) cents$")
    public void Advertiser_price_is_cents(int advertiserPrice) throws Throwable {
       context.setAdvertiserPrice(advertiserPrice);
    }

    @When("^advertisement sent$")
    public void advertisement_sent() throws Throwable {
        receivingSubscribers = subscriberBroadcast.send(context.getAdvertiserDemographic());
    }

    @Given("^Advertiser filters to Female gender$")
    public void Advertiser_filters_to_Female_gender() throws Throwable {
        context.setAdvertiserGenderFilter(Gender.Female);
    }

    @Then("^subscribers receiving advertisements$")
    public void subscribers_receiving_advertisements(List<Subscriber> expectedSubscribers) throws Throwable {
        assertEquals(expectedSubscribers.size(), receivingSubscribers.size());
        for(int i=0; i < expectedSubscribers.size(); i++){
            String expectedName = expectedSubscribers.get(i).name;
            String receivingName = receivingSubscribers.get(i).name;
            assertEquals(expectedName, receivingName);
        }
    }

}
