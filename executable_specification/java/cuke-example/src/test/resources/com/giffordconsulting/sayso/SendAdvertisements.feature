Feature: Send Advertisements

  Background:
    Given Sayso margin is 5 cents
    And Subscribers
    | name  | price | gender |
    | Lisa  |   10  |   Female    |
    | Bart  |   10  |   Male    |
    | Burns |   50  |   Male    |

  @sending
  Scenario: Send advertisements to price matched subscribers
    Given Advertiser price is 15 cents
    When advertisement sent
    Then subscribers receiving advertisements
        | Lisa |
        | Bart |

  @sending
  Scenario: Send advertisements to gender matched subscribers
    Given Advertiser price is 15 cents
    And Advertiser filters to Female gender
    When advertisement sent
    Then subscribers receiving advertisements
        | Lisa |

  @sending
  Scenario: Send advertisement without any subscribers
    Given Advertiser price is 2 cents
    When advertisement sent
    Then subscribers receiving advertisements
        |empty|