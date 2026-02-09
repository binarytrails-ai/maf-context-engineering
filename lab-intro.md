# ✈️ Contoso Travel Agency: Level Up Your AI Agent

**Mission:** Transform a basic travel FAQ bot into an intelligent trip planning assistant using Microsoft Agent Framework + CopilotKit

**Duration:** 90 minutes hands-on (Labs 0-7)

**Tech Stack:** .NET 10, Microsoft Agent Framework, CopilotKit (AG-UI), GitHub Models

---

## 🌟 The Vision: What You'll Build

By the end of this workshop, your Contoso Travel Agent will have this conversation:

```
👤 Traveler: "Hey, I want to plan a vacation"

🤖 TravelBot: "I'd love to help you plan your next adventure! 
              
              I see from your travel history that you visited Tasmania last year 
              in March and absolutely loved the Three Capes Track. 
              You mentioned wanting to explore more destinations in Victoria or New South Wales with 
              similar outdoor activities.
              
              Based on your preferences:
              • 🥾 Hiking and outdoor adventures
              • 🏖️ Coastal scenery
              • 💰 Budget-friendly travel (~$2,000-$2,500)
              • 🗓️ 10-14 day trips
              
              I'd suggest Croatia - specifically the Dalmatian Coast. It has 
              stunning hiking trails, crystal-clear beaches, and is about 30% 
              less expensive than Tasmania. Plus, March-April is perfect weather!
              
              Would you like me to explore this option?"

👤 Traveler: "Yeah that sounds great! How's the weather there?"

🤖 TravelBot: [Calls GetWeatherForecast("Croatia", "March")]
              
              "Let me pull the latest data... ✨
              
              📊 Croatia Weather (March-April):
              • Average: 15-18°C (59-64°F) - Perfect hiking weather!
              • Rainfall: Low (6-8 days/month)
              • Sunshine: 6-7 hours/day
              
              💡 Fun fact: You loved Tasmania's 17°C weather last March - 
              Croatia will be very similar!
              
              Now checking flights and hotels... 🔍"

🤖 TravelBot: [Calls SearchFlights(), SearchAccommodation(), CalculateCosts()]
              
              "💰 Here's the breakdown for a 12-day trip (March 15-27):
              
              ✈️ Flights: $1,250 return
              🏨 Accommodation: $720 (12 nights)
              🍽️ Meals & Activities: $480 ($40/day budget)
              ────────────────────────────────────────
              💵 Total Estimate: ~$2,450 AUD
              
              This is within your typical $2,000-$2,500 budget.
              
              Would you like me to add this to your calendar?"

👤 Traveler: "Yes! Can you block the dates?"

🤖 TravelBot: [Checks calendar conflicts]
              
              "Before I add this, I need to check something...
              
              ⚠️ I notice you have 'Q1 Team Offsite' on March 20-22. 
              This overlaps with your trip! Should we:
              A) Adjust trip dates to March 8-20 (avoid conflict)?
              B) Proceed anyway (you might need to reschedule offsite)?"

👤 Traveler: "Oh! Let's adjust to March 8-20"

🤖 TravelBot: [Updates dates, rechecks availability]
              
              "Smart choice! Adjusting to March 8-20 (12 days).
              ✅ No calendar conflicts
              ✅ Flights are actually $50 cheaper on these dates!
              
              [Creates approval workflow]
              
              I'll now create:
              📅 Calendar block: March 8-20, 2026 (Croatia Trip)
              ⏰ Reminder: Book flights by Feb 8
              ⏰ Reminder: Book accommodation by Feb 15
              ✅ Budget tracker: $2,400 allocated
              
              Ready to approve?"

👤 Traveler: "Yes, go ahead!"

🤖 TravelBot: [Waits for AG-UI approval confirmation]
              
              "🎉 All set! Your Croatia adventure is planned!
              
              📅 Added to calendar: March 8-20, 2026
              ⏰ Reminders set for booking milestones
              💾 Trip details saved to your travel history
              
              Want me to start researching hiking trails in Croatia now?"
```

---

## 🎯 Workshop Structure

### **Lab 0: Setup & Foundation (5 min)** ⚙️
**What You'll Build:** Run the basic FAQ bot and see its limitations

**The Problem:**
```
👤 Traveler: "I want to plan a vacation"
🤖 FAQ Bot: "We can help with flights, hotels, and activities. Where would you like to go?"
👤 Traveler: "Somewhere warm for hiking"
🤖 FAQ Bot: "We offer many destinations. Please specify a location."
❌ Useless! Can't make suggestions or access real data
```

**Key Concepts:**
- .NET 10 project structure
- GitHub Models integration (GPT-4o)
- AG-UI endpoint configuration
- Basic agent architecture

**What You'll Learn:**
- How to run an agent locally
- Test basic prompt/response flow
- Understand the starting limitations

---

### **Lab 1: Remember Me - Personalization & Memory (15 min)** 🧠
**What You'll Build:** Agent that remembers your preferences and personalizes recommendations

**The Gap:**
```
❌ BEFORE: Agent forgets everything, generic responses
👤 "I'm a budget backpacker who loves hiking, I'm vegetarian"
🤖 "Great! Where would you like to go?"

[Next day, new conversation]
👤 "Suggest a trip"
🤖 "Where would you like to go?" ❌ Forgot everything!
```

**The Fix:**
```
✅ AFTER: Persistent memory + personalized recommendations
👤 "I'm a budget backpacker who loves hiking, I'm vegetarian. 
    Went to Tasmania last March, loved the Three Capes Track!
    I've always wanted to visit Victoria, New South Wales, and New Zealand too."
🤖 [Stores to UserProfileMemory]
    "Got it! I'll remember your preferences 🥾
    
    Stored to memory:
    • Travel style: Budget backpacker
    • Interests: Hiking, coastal trails
    • Dietary: Vegetarian
    • Past trips: Tasmania (March 2024, loved it!)
    • Want to visit: Victoria, New South Wales, New Zealand"

👤 "Suggest a trip"
🤖 "Based on your hiking interests and vegetarian lifestyle, plus your 
    Tasmania experience, I'd suggest Victoria's Great Ocean Road..."

[Next day, NEW conversation]
👤 "Hey! Where did I say I wanted to travel?"
🤖 "You mentioned wanting to visit Victoria, New South Wales, and New Zealand! 
    
    Based on your profile:
    • Budget backpacker 🎒
    • Loves hiking, coastal trails 🥾  
    • Vegetarian 🌱
    • Loved Tasmania's Three Capes Track (March 2024)
    • Dream destinations: Victoria, New South Wales, New Zealand
    
    Would you like me to start planning one of these trips?" ✅ Remembers everything!

👤 "How many people usually travel with me?"
🤖 "From our conversations, you typically travel solo or with 1 companion. 
    Is this trip for solo travel or with others?"

👤 "What's my typical budget?"
🤖 "Your typical budget range is $2,000-$2,500 per trip, and you prefer 
    10-14 day trips. You're budget-conscious but willing to splurge on 
    experiences like unique hiking trails!"
👤 "I want to plan a trip"
🤖 "Great! Are you looking for adventure travel, relaxation, cultural exploration, 
    or something else? This helps me tailor recommendations to your style."

👤 "I'm a budget backpacker who loves hiking"
🤖 [Adapts entire personality + recommendations]
    "Awesome! As a fellow hiking enthusiast, I'd suggest destinations with:
    • Great trail systems
    • Budget-friendly hostels
    • Strong backpacker communities
    • Affordable local transport
    
    Thinking Victoria (Great Ocean Road) or New South Wales (Blue Mountains), or New Zealand (South Island)?
    Both have epic hiking and cost ~$30/day all-in!"
```

**Key Concepts:**
- `UserProfileMemoryProvider` - persistent memory across sessions
- Profile extraction from natural conversation
- Automatic data storage (travel style, budget, interests, past trips)
- Context injection before agent responds
- Personalized recommendations using stored data

**What You'll Store:**
```json
{
  "travelStyle": "budget backpacker",
  "budgetRange": "$2000-2500",
  "dietaryRestrictions": ["vegetarian"],
  "interests": ["hiking", "coastal trails", "photography"],
    "pastDestinations": [{
        "destination": "Tasmania",
        "date": "March 2024",
        "highlights": ["Three Capes Track"],
        "rating": "loved it"
    }],
    "placesToVisit": ["Victoria", "New South Wales", "New Zealand"],
  "numberOfTravelers": 1,
  "preferredSeason": "spring",
  "accommodationPreference": "hostels with private rooms",
  "budgetPerPerson": "$2000-2500",
  "tripDuration": "10-14 days",
  "languagesSpoken": "English, Spanish"
}
```

**Sample Memory Recall Questions:**
```
👤 "Where did I say I wanted to go?"
🤖 "You mentioned destinations in Victoria and New South Wales, and New Zealand!
    All perfect for hiking enthusiasts like you. Which one interests you most?"

👤 "How many people do I usually travel with?"
🤖 "Based on your profile, you typically travel solo. Is this trip 
    just for you or are you bringing someone along this time?"

👤 "When do I prefer to travel?"
🤖 "You prefer traveling in spring, and you like trips that last 10-14 days.
    You also prefer hostels with private rooms - social but with privacy!"

👤 "What kind of food can I eat?"
🤖 "You're vegetarian, so I'll make sure to recommend destinations with 
    excellent veggie options and avoid suggesting meat-heavy cuisines."

👤 "Where have I been before?"
🤖 "You visited Tasmania in March 2024 and absolutely loved the Three Capes Track!
    That trip really resonated with you. Want to find somewhere with similar vibes?"
```

**Why This Matters:**
- ✅ No onboarding friction (users just talk naturally)
- ✅ Cross-session persistence (not just conversation context)
- ✅ Incremental learning (profile builds over time)
- ✅ Truly personalized recommendations
- ✅ Multi-tenant ready (scoped by user/agent/app)

---

### **Lab 2: Remember Everything - Memory (15 min)** 🧠💾
**What You'll Build:** Long-term memory with vector store for retrieving past conversations

**The Gap:**
```
❌ BEFORE: Agent forgets long conversations
--- SESSION 1 (Week 1) ---
👤 "I'm vegetarian and love hiking"
🤖 "Got it!" [Stores to TravelerProfile]

--- SESSION 15 (Week 4, 50+ messages later) ---
👤 "Last month you suggested Croatia. What did we discuss about dietary options?"
🤖 "I don't have that context..." ❌ Conversation too long for context window!
```

**The Fix:**
```
✅ AFTER: Vector store retrieves relevant past conversations
--- SESSION 1 (Week 1) ---
👤 "I'm vegetarian and love hiking. Are there good veggie options in Croatia?"
🤖 "Yes! Croatian cuisine is Mediterranean-based with excellent vegetarian options:
    • Grilled vegetables, fresh salads
    • Dalmatian pastas with olive oil
    • Fresh seafood (if pescatarian)
    • Local markets with produce"
    [Stores conversation to vector database]

--- SESSION 15 (Week 4, 50+ messages later) ---
👤 "What did we discuss about vegetarian food in Croatia?"
🤖 [Searches vector store: "vegetarian Croatia food"]
    [Retrieves: Session 1 conversation]
    
    "In our conversation 3 weeks ago, we discussed Croatian vegetarian options:
    • Mediterranean-based cuisine with grilled veggies
    • Dalmatian pastas with olive oil
    • Fresh markets everywhere
    
    You were excited about the fresh local produce! 🥗"
```

**Two Types of Memory:**

1. **Short-Term Memory (Lab 1: UserProfileMemory)**
   - Structured user profile data
   - Travel style, budget, interests, past trips
   - Retrieved on every conversation
   ```json
   {
     "travelStyle": "budget backpacker",
     "interests": ["hiking"],
     "dietaryRestrictions": ["vegetarian"]
   }
   ```

2. **Long-Term Memory (Lab 2: Vector Store)**
   - Full conversation history across sessions
   - Semantic search for relevant context
   - Retrieved only when relevant
   ```
   User Query: "What restaurant did you recommend in Croatia?"
   → Vector Search: "restaurant recommendation Croatia"
   → Retrieved: "I suggested Konoba Matejuska in Split - 
                authentic Dalmatian cuisine with veggie options"
   ```

**What You'll Implement:**

```csharp
// Store conversations in vector database
public async Task StoreConversationAsync(string userId, Message message)
{
    var embedding = await _embeddingService.GenerateEmbeddingAsync(message.Content);
    await _vectorStore.UpsertAsync(new ConversationMemory
    {
        UserId = userId,
        Content = message.Content,
        Timestamp = DateTime.UtcNow,
        Embedding = embedding
    });
}

// Retrieve relevant past conversations
public async Task<List<Message>> SearchMemoryAsync(string userId, string query)
{
    var queryEmbedding = await _embeddingService.GenerateEmbeddingAsync(query);
    var results = await _vectorStore.SearchAsync(
        userId, 
        queryEmbedding, 
        topK: 5,
        similarityThreshold: 0.7
    );
    return results.Select(r => r.ToMessage()).ToList();
}
```

**Sample Retrieval:**
```
👤 "I think you mentioned something about travel insurance last time?"

🤖 [Searches vector store]
    Query: "travel insurance recommendation"
    
    Found 2 relevant conversations:
    
    📅 March 10 (3 weeks ago):
    "I recommended World Nomads for budget travelers - 
    covers adventure activities like hiking."
    
    📅 March 15 (2 weeks ago):
    "You asked about coverage limits. World Nomads offers 
    $100K medical + $2,500 trip cancellation."
    
    "Yes! We discussed World Nomads travel insurance. 
    It's great for budget travelers and covers hiking activities. 
    Would you like me to get you a quote?"
```

**Key Concepts:**
- Vector databases (Azure AI Search, Pinecone, Qdrant)
- Embedding generation for semantic search
- Similarity thresholds and relevance scoring
- When to use structured memory vs vector search
- Privacy and data retention for long-term storage

**Why This Matters:**
- ✅ Overcomes context window limitations (works with 100+ session history)
- ✅ Semantic search retrieves relevant context automatically
- ✅ Enables long-term relationship building with users
- ✅ Recalls specific details from any past conversation

---

### **Lab 3: Give It Superpowers - Tools (20 min)** 🔧
**What You'll Build:** Connect your agent to real-world data sources via tool calls

**The Gap:**
```
❌ BEFORE: Agent guesses or makes up data
👤 "What's the weather like in Croatia in March?"
🤖 "March is generally mild in Croatia, around 12-15°C."
(No real data - could be completely wrong!)

👤 "Find me flights from Seattle to Croatia"
🤖 "I'd recommend checking Google Flights..."
(Can't actually search - just tells you what to do!)
```

**The Fix:**
```
✅ AFTER: Agent calls real APIs via tools
👤 "What's the weather like in Croatia in March?"
🤖 [Calls GetWeatherForecast("Croatia", "March")]
    "📊 Croatia Weather in March (from weather API):
    • Temperature: 12-15°C (54-59°F)
    • Rainfall: Low (60mm avg)
    • Sunshine: 6-7 hours/day
    • Perfect for hiking!"

👤 "Find me flights from Seattle to Croatia next month for 2 weeks, budget $2500"
🤖 [LLM extracts: origin="Seattle", destination="Croatia", 
                  dates="2026-02-01 to 2026-02-15", maxBudget=2500]
    [Calls SearchFlights with extracted parameters]
    
    "Found 3 flights within your budget:
    1. Delta DL627 - $1,250 (1 stop)
    2. United UA832 - $1,400 (direct)
    3. Lufthansa LH441 - $1,350 (1 stop)"
```

**The Magic: LLM Extracts Parameters from Natural Language**

The LLM does the hard work of understanding messy human input:

```
👤 "I want to go to Bali from March 10 to March 20 with my partner, 
    budget around $2,500"

🤖 [LLM understands and extracts:]
    ✓ destination = "Bali, Indonesia"
    ✓ departureDate = "2026-03-10"
    ✓ returnDate = "2026-03-20"
    ✓ travelers = 2
    ✓ maxBudget = 2500
    
    [Calls SearchFlights("Seattle", "Bali", "2026-03-10", "2026-03-20", 2500)]
    [Calls SearchAccommodation("Bali", "2026-03-10", "2026-03-20", 2)]
```

More examples of LLM parameter extraction:

```
👤 "Next month for 2 weeks"
🤖 [Extracts: departureDate="2026-02-01", returnDate="2026-02-15"]

👤 "Under three grand"
🤖 [Extracts: maxBudget=3000]

👤 "Me and my wife" 
🤖 [Extracts: travelers=2]

👤 "Around spring break"
🤖 [Calls GetCurrentDate, calculates: departureDate="2026-03-15"]
```

**Tools You'll Implement:**

```csharp
// 1. Weather Tool - Returns real-time weather data
[Description("Get weather forecast for a destination in a specific month")]
public static async Task<string> GetWeatherForecast(
    [Description("Destination city or country")] string location,
    [Description("Month name (e.g., 'March')")] string month)
{
    // Call real weather API
    var data = await WeatherAPI.GetForecastAsync(location, month);
    return JsonSerializer.Serialize(data);
}

// 2. Flight Search Tool - Returns available flights with prices
[Description("Search for flights between two cities with dates and budget")]
public static async Task<string> SearchFlights(
    [Description("Departure city (e.g., 'Seattle', 'SEA')")] string origin,
    [Description("Destination city (e.g., 'Tokyo', 'Croatia')")] string destination,
    [Description("Departure date in YYYY-MM-DD format")] string departureDate,
    [Description("Return date in YYYY-MM-DD format")] string returnDate,
    [Description("Maximum budget in USD (optional)")] decimal? maxBudget = null)
{
    // Call real flight API
    var flights = await FlightAPI.SearchAsync(origin, destination, ...);
    return JsonSerializer.Serialize(flights);
}

// 3. Calendar Tool - Check for conflicts
[Description("Check if user has calendar conflicts during travel dates")]
public static async Task<string> CheckCalendarConflicts(
    [Description("Trip start date in YYYY-MM-DD format")] string startDate,
    [Description("Trip end date in YYYY-MM-DD format")] string endDate)
{
    // Call calendar API
    var conflicts = await CalendarAPI.GetConflictsAsync(startDate, endDate);
    return JsonSerializer.Serialize(conflicts);
}
```

**How It Works: The Tool Calling Flow**

```
1. USER INPUT (Natural Language):
   "Find cheap flights to Japan next spring for about 10 days"

2. LLM UNDERSTANDS & EXTRACTS:
   → Destination: "Japan" (or "Tokyo" if it knows your preference)
   → Timing: "next spring" → Calls GetCurrentDate → "2026-04-01"
   → Duration: "10 days" → returnDate = "2026-04-11"
   → Budget constraint: "cheap" → maxBudget = 1000 (infers from "cheap")

3. LLM CALLS TOOL WITH STRUCTURED PARAMETERS:
   SearchFlights(
     origin: "Seattle",        ← From user context
     destination: "Tokyo",     ← Extracted from "Japan"
     departureDate: "2026-04-01",
     returnDate: "2026-04-11",
     maxBudget: 1000
   )

4. TOOL EXECUTES:
   → Calls real Flight API
   → Returns structured JSON: [Flight1, Flight2, Flight3]

5. LLM FORMATS RESPONSE (Natural Language):
   "I found 3 affordable flights to Tokyo in April:
   
   1. ANA Flight NH178 - $850 (direct, 11h)
   2. United UA837 - $780 (1 stop, 14h)
   3. JAL JL061 - $920 (direct, 10.5h)
   
   All within your budget! Want details on any of these?"
```

**Key Concepts:**

1. **Type-Safe Parameters** - Framework enforces correct types:
   ```csharp
   string origin              // LLM must provide text
   decimal? maxBudget         // LLM must provide number (or null)
   string departureDate       // LLM must provide text in YYYY-MM-DD
   ```

2. **Parameter Descriptions** - Guide the LLM on what to extract:
   ```csharp
   [Description("Departure city (e.g., 'Seattle', 'SEA')")]
   ```
   This tells the LLM: "Extract the departure city from user input"

3. **Tool Registration** - Simple registration with `AIFunctionFactory`:
   ```csharp
   Tools = [
       AIFunctionFactory.Create(DateTimeTools.GetCurrentDate),
       AIFunctionFactory.Create(TravelSearchTools.SearchFlights),
       AIFunctionFactory.Create(TravelSearchTools.CheckCalendarConflicts)
   ]
   ```

4. **Tool Chaining** - LLM can call multiple tools:
   ```
   User: "Plan a trip next month"
   → Call GetCurrentDate() to resolve "next month"
   → Call SearchFlights() with calculated dates
   → Call CheckCalendarConflicts() to validate dates
   → Present complete plan to user
   ```

**Sample Complex Flow:**

```
👤 "My wife and I want to visit Greece for our anniversary in June, 
    staying about 2 weeks, budget flexible but under $5k"

🤖 [LLM extracts multiple parameters:]
    
    Step 1: Identify missing info
    ✓ Travelers: 2 (mentioned "my wife and I")
    ✓ Destination: "Greece"
    ✓ Month: "June"
    ✓ Duration: ~14 days
    ✓ Budget: <$5000
    ✗ Origin: Unknown → Call GetUserContext() → "Seattle"
    ✗ Exact dates: "June" → Call GetCurrentDate() → Calculate June window
    
    Step 2: Call tools with extracted data
    → SearchFlights("Seattle", "Greece", "2026-06-01", "2026-06-15", 2500)
    → SearchAccommodation("Greece", "2026-06-01", "2026-06-15", 2, 2500)
    
    Step 3: Present results
    "🇬🇷 Perfect anniversary destination! Here's what I found:
    
    ✈️ Flights: $1,800 for both (round-trip)
    🏨 Hotels: $2,100 (14 nights, 4-star romantic hotels)
    🍽️ Estimated daily: $1,100 (meals + activities)
    ─────────────────────
    💰 Total: ~$5,000 (right at your budget!)
    
    This includes romantic hotels in Santorini and Athens.
    Want me to check your calendar for conflicts?"
```

**Why This Matters:**

- ✅ **Real data** - No more hallucinations or guesses
- ✅ **Natural input** - Users don't need to format dates or provide structured data
- ✅ **LLM does the work** - Extracts, converts, and validates parameters
- ✅ **Type safety** - Framework ensures tools get correct data types
- ✅ **Integration-ready** - Tools can call any API (flights, hotels, weather, calendar)

**What You'll Learn:**

1. How to define tools with `[Description]` attributes
2. How LLM extracts parameters from natural language
3. How to register tools with `AIFunctionFactory`
4. How to chain multiple tool calls for complex queries
5. When to use tools vs when agent can answer directly

---

### **Lab 4: See Under the Hood - Observability (10 min)** 👁️
**What You'll Add:** Production monitoring with Application Insights for debugging and cost tracking

**The Gap:**
```
❌ BEFORE: No visibility into agent behavior
Customer: "Your agent gave me wrong flight prices!"
Developer: "Let me check the code... 🤷" ← Takes hours to debug
```

**The Fix:**
```
✅ AFTER: Complete visibility into agent operations
Developer: [Opens Application Insights]
           [Finds conversation trace in 30 seconds]
           
📊 Trace: SearchFlight Call
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
1. User Input: "Find flights to Croatia..."

2. Model Processing (GPT-4o)
   • Extracted params: origin="Seattle", dest="Croatia"
   • Tokens: 842 input / 156 output
   • Cost: $0.024
   • Latency: 1.2s

3. Tool Call: SearchFlight
   • API: flights.contoso.com/search
   • Response time: 890ms
   • Results: 3 flights

4. Model Response
   • Formatted results
   • Cost: $0.015
   • Total: 3.1s, $0.039

Developer: "Found the bug - cached prices from yesterday!"
```

**What You'll Implement:**

1. **Application Insights Integration**
   ```csharp
   telemetry.TrackEvent("TripPlanned", new {
       destination = "Croatia",
       budget = 2500,
       toolsCalled = ["SearchFlights", "GetWeather"],
       durationMs = 2340,
       cost = 0.039
   });
   ```

2. **Tool Call Tracing**
   - Track every tool invocation
   - Measure latency and success rate
   - Log input/output for debugging

3. **Cost Tracking**
   - Token usage per request
   - Daily/monthly cost aggregation
   - Cost alerts and optimization

**Key Concepts:**
- Telemetry and distributed tracing
- OpenTelemetry integration
- Cost tracking and optimization
- Error patterns and alerting
- Performance monitoring

**Why This Matters:**
- ✅ Debug production issues in minutes, not hours
- ✅ Track costs and optimize spend
- ✅ Identify performance bottlenecks
- ✅ Proactive error detection

---

### **Lab 5: Human-in-the-Loop - Approval Workflows (10 min)** ✋
**What You'll Build:** Safe execution of consequential actions with user approval

**The Gap:**
```
❌ BEFORE: Agent can't perform actions, or does them unsafely
👤 "Book the Delta flight"
🤖 "I can't actually book flights, but here's what you should do..."
```

**The Fix:**
```
✅ AFTER: Agent performs actions with approval
👤 "Book the Delta flight"
🤖 [Calls BookFlight tool - requires approval]
    
    "📋 Flight Booking Request:
    ━━━━━━━━━━━━━━━━━━━━━━
    Flight: Delta DL627
    Route: Seattle → Croatia
    Dates: March 10-24, 2025
    Cost: $1,250.00
    ━━━━━━━━━━━━━━━━━━━━━━
    
    This requires your approval to proceed."
    
    [AG-UI shows approval widget]

👤 [Clicks Approve]

🤖 "✅ Booking Confirmed!
    
    Confirmation: DL-2025-ABC123
    E-ticket sent to: your@email.com
    Added to calendar: March 10-24
    
    💡 Next steps:
    • Web check-in opens 24h before
    • Passport required
    • Baggage: 1 carry-on + 1 checked"
```

**Tools with Approval:**

1. **BookFlight** - Requires approval before execution
2. **CreateCalendarEvent** - Can modify schedule
3. **SendEmail** - Can communicate on your behalf

**Key Concepts:**
- Human-in-the-loop pattern
- Approval workflows with AG-UI
- Tool execution only after approval granted
- Audit trail for actions
- Safety for consequential operations

**Why This Matters:**
- ✅ Prevents accidental bookings or charges
- ✅ User maintains control over important actions
- ✅ Clear approval process with confirmation
- ✅ Production-ready safety pattern

---

### **Lab 6: Specialist Team - Multi-Agent (12 min)** 🤝
**What You'll Build:** Coordinator agent that delegates to specialists

**The Gap:**
```
❌ BEFORE: One agent tries to do everything (poorly)
👤 "Plan my complete Croatia trip - flights, hotels, activities, and update my calendar"
🤖 [One agent struggles with complexity]
    "Let me help... *gets confused trying to handle flights, hotels, activities,
    calendar conflicts all at once*"
    (Makes mistakes, misses details, poor quality)
      "travelers": 2,
      "budget_total": 2500,
      "budget_per_person": 1250
    }
    
    "Got it! Planning a 10-day Bali trip for 2 people:
    
    📅 Dates: March 10-20, 2026
    👥 Travelers: 2
    💰 Budget: $2,500 ($1,250 per person, $125/person/day)
    
    This is doable! Bali is very budget-friendly. 
    Searching for flights and accommodation now..."
```

**Key Concepts:**
- JSON schema enforcement
- Response parsing and validation
- Data transformation between tools
- Error handling for malformed data

**Structured Data You'll Extract:**

1. **Trip Details**
   ```json
   {
     "destination": "Croatia",
     "dates": {
       "start": "2026-03-08",
       "end": "2026-03-20",
       "duration_days": 12
     },
     "travelers": {
       "adults": 2,
       "children": 0
     },
     "budget": {
       "total": 3000,
       "currency": "USD",
       "per_person_per_day": 125
     }
   }
   ```

2. **Flight Preferences**
   ```json
   {
     "departure_airport": "LAX",
     "destination": "DBV",
     "dates": {
       "outbound": "2026-03-08",
       "return": "2026-03-20"
     },
     "class": "economy",
     "max_stops": 1,
     "preferences": ["window_seat", "morning_departure"]
   }
   ```

3. **Accommodation Requirements**
   ```json
   {
     "type": "hotel",
     "star_rating": "3-4",
     "amenities": ["wifi", "breakfast", "pool"],
     "location_preference": "near_beach",
     "budget_per_night": 120
   }
   ```

**Sample Complex Extraction:**
```
👤 "My wife and I want to visit Greece for our anniversary in June, staying about 
    2 weeks, we love history and beaches, budget is flexible but prefer to keep it 
    under $5k, we want nice hotels but not crazy luxury, and we need to be back by 
    June 20th because I have a work thing"

🤖 [Extracts detailed structured data]
    {
      "destination": "Greece",
      "occasion": "anniversary",
      "travelers": 2,
      "relationship": "married_couple",
      "dates": {
        "month": "June",
        "year": 2026,
        "duration": "~14 days",
        "hard_constraint": "must return by 2026-06-20"
      },
      "interests": ["history", "beaches", "cultural_sites"],
      "budget": {
        "max": 5000,
        "flexibility": "moderate",
        "style": "upper-mid-range (4-star, not luxury)"
      },
      "preferences": {
        "accommodation": "nice hotels (4-star preferred)",
        "avoid": "budget hostels, basic accommodation"
      }
    }
    
    "🇬🇷 Perfect anniversary destination! Let me plan this special trip:
    
    📅 Suggested dates: June 6-20 (14 days, back by your deadline)
    👥 Couple's trip (anniversary celebration!)
    
    🏛️ Itinerary structure for history + beaches:
    • Athens (3 days): Acropolis, ancient sites
    • Santorini (5 days): Romantic sunset, beaches
    • Crete (6 days): Minoan history + beautiful coasts
    
    💰 Budget estimate:
    • Flights: $1,400 (2 people)
    • Hotels: $2,100 (14 nights, 4-star, ~$150/night)
    • Meals & activities: $1,200
    • Internal flights/ferries: $300
    ──────────────────────────
    Total: $5,000 (at your max budget)
    
    Want me to find slightly cheaper options or is this perfect?"
```

**Why This Matters:**
- ✅ Booking systems need structured data (APIs don't understand "around March")
- ✅ Calendar integrations require exact dates
- ✅ Payment systems need precise amounts
- ✅ Enables reliable tool chaining

---

### **Lab 4: Remember Everything - Memory (15 min)** 🧠
**What You'll Build:** Short-term context + long-term user memory

**The Gap:**
```
❌ BEFORE: Agent forgets everything
--- SESSION 1 ---
👤 "I'm vegetarian and I love hiking"
🤖 "Great, I'll keep that in mind!"

--- SESSION 2 (Next day) ---
👤 "Suggest a trip for me"
🤖 "Where would you like to go?"
(Forgot vegetarian preference and hiking interest!)
```

**The Fix:**
```
✅ AFTER: Persistent memory across sessions
--- SESSION 1 ---
👤 "I'm vegetarian and I love hiking"
🤖 [Stores to long-term memory]
    user_preferences: {
      dietary: "vegetarian",
      interests: ["hiking", "outdoor_activities"]
    }
    "Got it! I'll remember you're vegetarian and love hiking 🥾"

--- SESSION 2 (Next day, new conversation) ---
👤 "Suggest a trip for me"
🤖 [Retrieves from memory]
    "Based on your love for hiking and vegetarian lifestyle, I'd suggest:
    
    • Nepal: Epic Himalayan treks + veggie-friendly dal bhat
    • New Zealand: World-class hiking trails + great veggie options
    • Peru: Inca Trail + abundant vegetarian Peruvian cuisine
    
    Which style appeals more - high-altitude adventure or coastal hikes?"
```

**Two Types of Memory:**

1. **Short-Term Memory (Conversation Context)**
   - Lives within current session only
   - Managed by conversation history
   - Lost when session ends
   ```
   👤 "I have $2,000 budget"
   [3 messages later in SAME conversation]
   👤 "Show me options"
   🤖 "Here are options under $2,000..." ✅ Remembers from context
   ```

2. **Long-Term Memory (Persistent Storage)**
   - Survives across sessions
   - Stored in database/vector store
   - Retrieved when relevant
   ```
    --- March 2025 ---
    👤 "I loved Tasmania! The Three Capes Track was amazing!"
    🤖 [Saves: past_trips["Tasmania"] = {rating: 5/5, loved: "Three Capes Track"}]
   
   --- September 2025 (6 months later, NEW session) ---
   👤 "Where should I travel next?"
   🤖 [Retrieves memory] "You loved Tasmania's Three Capes Track last March!
       Want something similar? Victoria, New South Wales, or New Zealand all have 
       stunning coastal hiking trails."
   ```

**What You'll Store:**

```json
{
  "user_id": "traveler_123",
  "profile": {
    "travel_style": "budget_backpacker",
    "interests": ["hiking", "photography", "local_food"],
    "dietary_restrictions": ["vegetarian"],
    "budget_range": "1500-2500_per_trip",
    "preferred_trip_duration": "10-14_days"
  },
    "past_trips": [
        {
            "destination": "Tasmania",
            "date": "2024-03-15",
            "rating": 5,
            "highlights": ["Three Capes Track", "coastal hiking", "friendly locals"],
            "lowlights": ["variable weather on exposed cliffs"]
        }
    ],
  "preferences": {
    "flight": {
      "seat": "window",
      "time": "morning_departure_preferred"
    },
    "accommodation": {
      "type": "hostel_with_private_room",
      "must_have": ["wifi", "kitchen"]
    }
  },
  "upcoming_trips": [
    {
      "destination": "Croatia",
      "dates": "2026-03-08 to 2026-03-20",
      "status": "planning"
    }
  ]
}
```

**Sample "Magical Memory" Conversation:**
```
👤 "I need a vacation"

🤖 [Retrieves comprehensive memory]
    "I'd love to help! Let me think about what would be perfect for you...
    
    🧠 Based on what I know:
    • You're a budget traveler (~$2,000-2,500 per trip)
    • You LOVED Tasmania's Three Capes Track last year (rated 5/5)
    • You're vegetarian (need good veggie food options)
    • You prefer 10-14 day trips
    • You like morning flights and window seats
    • You enjoy hostels with private rooms (social but with privacy)
    
    Given it's been 6 months since Tasmania, I suggest:

    🇦🇺 Victoria — Great Ocean Road (Similar coastal vibes):
    • Great Ocean Walk with cliff-top views and beaches
    • Budget-friendly: $40-50/day all-in
    • Easy access from Melbourne; vegetarian options abound

    🇦🇺 New South Wales — Blue Mountains (Inland cliffs and waterfalls):
    • Cliff-top tracks, canyons, and lookouts
    • Affordable hostels and trains from Sydney
    • Excellent mix of day hikes

    🇳🇿 New Zealand — South Island (Alpine alternative):
    • Coastal + alpine scenery; many hut-based trails
    • Wider range of multi-day walks
    • Great for shoulder-season hiking
    
    Which vibe calls to you?"

👤 "Wow, you remembered all that! Croatia sounds perfect!"

🤖 "That's what I'm here for! 😊 
    
    And I remember you said Portuguese coastal hikes were 'the best 
    experience of your life' - Croatia's Dalmatian Coast trail will 
    give you that same magical feeling but with fewer crowds.
    
    Let's plan it! When are you thinking?"
```

**Key Concepts:**
- Thread management & session persistence
- Conversation state vs persistent memory
- Memory retrieval strategies (when to recall what)
- Privacy & data retention policies

---

### **Lab 5: Specialist Team - Multi-Agent (12 min)** 🤝
**What You'll Build:** Coordinator agent that delegates to specialists

**The Gap:**
```
❌ BEFORE: One agent tries to do everything (poorly)
👤 "Plan my complete Croatia trip - flights, hotels, activities, and update my calendar"
🤖 [One agent struggles with complexity]
    "Let me help... *gets confused trying to handle flights, hotels, activities,
    calendar conflicts all at once*"
    (Makes mistakes, misses details, poor quality)
```

**The Fix:**
```
✅ AFTER: Specialist agents work together
👤 "Plan my complete Croatia trip - flights, hotels, activities, and update my calendar"

🤖 Main Agent: [Analyzes request, delegates to specialists]
    "I'll coordinate the team to handle this complex request:
    
    🛫 Flight Agent: Searching best flights...
    🏨 Hotel Agent: Finding accommodation...  
    🎯 Activity Agent: Curating experiences...
    📅 Calendar Agent: Checking conflicts..."

[Flight Agent works independently]
    ✅ Found flights: $1,250 (best price with 1 stop)

[Hotel Agent works independently]
    ✅ Secured hotels: $720 for 12 nights (great locations)

[Activity Agent works independently]
    ✅ Curated itinerary: Hiking, kayaking, wine tours

[Calendar Agent works independently]
    ⚠️ Detected conflict: Team offsite March 20-22
    💡 Suggested alternative: March 8-20 (no conflicts)

🤖 Main Agent: [Coordinates responses]
    "✅ Your team has planned everything!
    
    Trip Summary for Croatia (March 8-20):
    • ✈️ Flights: $1,250 (adjusted dates to avoid conflict)
    • 🏨 Hotels: $720 (coastal towns, highly rated)
    • 🎯 Activities: 5 hiking trails, 2 wine tours, kayaking day trip
    • 📅 Calendar: Updated (no conflicts!)
    
    Total: $2,450 - Ready to book?"
```

**The Agent Team You'll Build:**

1. **Main Agent (Coordinator)**
   - Routes requests to specialists
   - Coordinates responses
   - Handles complex multi-step queries
   ```csharp
   if (query.contains("flights")) → delegate to FlightAgent
   if (query.contains("hotels")) → delegate to HotelAgent
   if (complex_trip_planning) → delegate to ALL agents
   ```

2. **Flight Agent (Specialist)**
   - Expert in flight search
   - Knows airline policies
   - Optimizes for price vs convenience
   ```csharp
   SearchFlights(origin, destination, dates, preferences)
   CompareAirlines(route)
   CheckBaggageRules(airline)
   ```

3. **Hotel Agent (Specialist)**
   - Expert in accommodation
   - Knows neighborhoods
   - Matches hotels to traveler style
   ```csharp
   SearchHotels(destination, dates, budget, style)
   GetNeighborhoodInfo(city, neighborhood)
   CheckAmenities(hotel)
   ```

4. **Activity Agent (Specialist)**
   - Expert in local experiences
   - Curates itineraries
   - Knows seasonal activities
   ```csharp
   SuggestActivities(destination, interests, season)
   CreateDailyItinerary(trip_details)
   CheckActivityAvailability(activity, date)
   ```

5. **Calendar Agent (Specialist)**
   - Expert in scheduling
   - Detects conflicts
   - Optimizes trip timing
   ```csharp
   CheckCalendarConflicts(start_date, end_date)
   FindAvailableWindows(duration, constraints)
   BlockCalendar(trip_details)
   ```

**When to Use Multi-Agent vs Single Agent:**

```
✅ USE MULTI-AGENT when:
• Task requires different domains of expertise
• Subtasks can run in parallel (faster!)
• Each component is complex enough to warrant specialization
• Different agents need different tools/data sources

❌ USE SINGLE AGENT when:
• Simple, single-domain query
• Task doesn't benefit from specialization
• Coordination overhead > benefit
• Latency matters more than quality

EXAMPLES:

✅ Multi-Agent: "Plan 2-week Europe trip with flights, hotels, activities"
   → Flight, Hotel, Activity, Calendar agents all contribute

❌ Single Agent: "What's the weather in Paris?"
   → Just call weather API, no need for specialists

✅ Multi-Agent: "I have $3k and 2 weeks - suggest destinations, compare costs"
   → Research Agent finds options, Finance Agent compares costs

❌ Single Agent: "What's the cheapest flight to Tokyo?"
   → Single Flight Agent can handle this
```

**Sample Complex Multi-Agent Conversation:**
```
👤 "I want to surprise my wife for our anniversary. She loves Italy. Budget is 
    $5,000, and I need this planned within an hour because I want to tell her tonight!"

🤖 Main Agent: "🎉 Anniversary surprise in Italy! I've got you covered. Calling in the specialists...

[All agents work in PARALLEL - this is key!]

🛫 Flight Agent:
    "Searching premium options for special occasion...
    ✅ Business class available: LAX → Rome ($3,200 for 2)
    ✅ Backup economy with extra legroom: $1,800"

🏨 Hotel Agent:
    "Finding romantic hotels for anniversary...
    ✅ 5-star Rome hotel with Colosseum view: $380/night
    ✅ Luxury Tuscan villa: $450/night (more romantic!)
    ✅ Venice canal-side boutique: $320/night"

🎯 Activity Agent:
    "Curating romantic Italian experiences...
    ✅ Private sunset wine tour in Tuscany
    ✅ Cooking class for couples in Rome
    ✅ Gondola ride + dinner in Venice
    ✅ Hot air balloon over Tuscan countryside"

💰 Finance Agent:
    "Calculating total costs for 10-day trip...
    
    OPTION A (Luxury):
    • Flights: $3,200 (business class)
    • Hotels: $3,600 (luxury tier)
    • Activities: 800 AUD
    Total: $7,600 ⚠️ Over budget

    OPTION B (Romantic + Smart):
    • Flights: $1,800 (premium economy)
    • Hotels: $2,400 (4-5 star mix)
    • Activities: $600
    • Special: $200 (anniversary dinner upgrade)
    Total: $5,000 ✅ Perfect fit!"

🤖 Main Agent: [Coordinates all input]
    "✅ Your perfect anniversary surprise is ready!
    
    🇮🇹 10-Day Italian Romance (Option B):
    
    📅 Rome (4 nights): Historic charm + couples cooking class
    📅 Tuscany (3 nights): Luxury villa + private wine tour
    📅 Venice (3 nights): Canal-side hotel + gondola dinner
    
    ✈️ Premium economy flights with extra legroom
    🏨 Mix of 4-5 star romantic hotels
    🍷 Includes special experiences for anniversary
    
    💰 Total: Exactly $5,000
    ⏱️ Planned in 12 minutes (you have time to surprise her!)
    
    Want me to book this now?"

👤 "This is perfect! Book it!"

🤖 Main Agent: [Coordinates booking across all agents]
    
    [Flight Agent books flights]
    ✅ Flights confirmed
    
    [Hotel Agent books hotels]
    ✅ All 3 hotels confirmed
    
    [Activity Agent books experiences]
    ✅ Cooking class, wine tour, gondola booked
    
    [Calendar Agent updates schedule]
    ✅ Vacation added to calendar, OOO set
    
    "🎉 EVERYTHING BOOKED! Confirmation emails sent.
    
    💡 Pro tip for tonight: I've created a beautiful PDF itinerary 
    you can print and give her as the 'reveal'. Check your email!
    
    Happy anniversary! 🥂"
```

**Key Concepts:**
- Agent routing and orchestration
- Specialized vs generalist agents
- Parallel execution (speed!)
- Context sharing between agents
- Agent composition patterns

---

## 🎓 Advanced Topics (Optional)

### **Lab 6: See Inside - Observability (10 min)** 👁️
**What You'll Add:** Production monitoring and debugging capabilities

**Why It Matters:**
```
🐛 PRODUCTION BUG:
Customer: "Your agent recommended flights for 800 AUD but they're actually $1,200!"

Without observability:
❌ "Um... let me check the code?"
❌ Takes hours to reproduce
❌ Can't see what the agent actually did

With observability:
✅ Pull up trace in 30 seconds
✅ See exactly which API was called
✅ Find the bug: Agent used cached prices from yesterday
✅ Fix deployed in minutes
```

**What You'll Implement:**

1. **Application Insights Integration**
   ```csharp
   // Track every agent interaction
   telemetry.TrackEvent("TripPlanned", new {
       destination = "Croatia",
       budget = 2500,
       toolsCalled = ["SearchFlights", "SearchHotels"],
       duration_ms = 2340,
       success = true
   });
   ```

2. **Tool Call Tracing**
   ```
   📊 TRACE LOG for "Plan Croatia trip":
   [10:15:23.001] Request received
   [10:15:23.045] Intent: trip_planning
   [10:15:23.102] Delegate to Flight Agent
   [10:15:24.201] Tool: SearchFlights("Croatia", "March") → $1,250
   [10:15:24.301] Tool: SearchHotels("Croatia", "March") → $720
   [10:15:25.102] Tool: CheckCalendar("2026-03-15", "2026-03-27") → conflict detected
   [10:15:25.150] Tool: CheckCalendar("2026-03-08", "2026-03-20") → no conflicts
   [10:15:25.890] Response generated
   [10:15:25.920] Total duration: 2.9s
   [10:15:25.920] Tokens used: 1,247 (cost: $0.0187)
   ```

3. **Cost Tracking**
   ```
   💰 DAILY COST DASHBOARD:
   
   Today (Dec 29):
   • Requests: 1,247
   • Total tokens: 1,563,890
   • GPT-4o cost: $23.45
   • Avg cost per request: $0.0188
   
   Most expensive queries:
   1. Complex multi-destination trip: $0.45 (32K tokens)
   2. Full itinerary with activities: $0.31 (21K tokens)
   3. Flight comparison across 5 cities: $0.28 (19K tokens)
   
   ⚠️ Alert: Cost +15% vs yesterday (investigate)
   ```

4. **Error Tracking**
   ```
   🚨 ERRORS (Last 24h):
   
   1. FlightAPI timeout (12 occurrences)
      → Impact: 12 failed trip plans
      → Fix: Increase timeout from 5s → 10s
   
   2. Calendar sync failed (3 occurrences)
      → Impact: Booked trips with conflicts
      → Fix: Add retry logic + user confirmation
   
   3. Invalid date parsing (45 occurrences)
      → Impact: Confused users
      → Fix: Improve date extraction prompt
   ```

**Sample Debug Session:**
```
👤 "Why did your agent book expensive flights?"

🤖 Agent Developer: [Pulls up traces]
    "Let me check the trace for your booking...
    
    📊 Found it! Booking ID: TRV-2025-8472
    
    [10:42:15] User: 'Find cheapest flights to Tokyo'
    [10:42:16] FlightAgent called SearchFlights(
                  destination='Tokyo',
                  sortBy='price_asc'  ← Should be sorting by price!
               )
    [10:42:17] API returned: [
                  {airline: 'Scoot', price: 685, stops: 2},
                  {airline: 'ANA', price: 1250, stops: 0}  ← This was returned first
               ]
    [10:42:17] Agent selected: ANA $1,250  ← BUG HERE!
    
    🐛 ROOT CAUSE: Agent has a bug - it's selecting first result instead 
       of cheapest result after API call.
    
    🔧 FIX: Update agent logic to sort results by price after API response.
    
    💵 REFUND: I've processed a $565 refund (difference in price).
    
    ✅ Bug fixed, deployed to production. Won't happen again!"
```

**Key Concepts:**
- Telemetry and distributed tracing
- OpenTelemetry integration
- Cost tracking and optimization
- Error patterns and alerting
- Performance monitoring

---

### **Lab 7: Learn from Users - Feedback (Homework)** 📈
**What You'll Add:** Feedback collection and continuous improvement loops

**Concept Overview:**
```
👤 Traveler: "Plan a trip to Iceland"
🤖 TravelBot: "Here's a 10-day Iceland itinerary for $3,500..."

[Feedback UI appears]
👤 Traveler: 👎 "Too expensive! I said budget-friendly!"

📊 FEEDBACK LOGGED:
{
  "rating": "negative",
  "reason": "exceeded_budget",
  "context": {
    "user_profile": "budget_traveler",
    "recommended_cost": 3500,
    "expected_cost": "under_2000"
  },
  "action": "Agent ignored budget traveler profile"
}

🔧 SYSTEM LEARNS:
• Budget travelers expect <$2,000 recommendations
• Update agent instructions to check profile
• Add budget validation before presenting options
```

**Key Concepts:**
- Feedback collection UI patterns
- A/B testing frameworks
- User satisfaction metrics (CSAT, NPS)
- Iterative prompt improvement

---

### **Lab 8: Never Break Again - Testing (Homework)** ✅
**What You'll Add:** Comprehensive test coverage for reliability

**Test Types:**

1. **Unit Tests (Tools in Isolation)**
   ```csharp
   [Fact]
   public void SearchFlights_ValidDestination_ReturnsFlights()
   {
       var flightAgent = new FlightAgent();
       var results = flightAgent.SearchFlights("Tokyo", "2026-03-15");
       
       Assert.NotEmpty(results);
       Assert.All(results, f => Assert.True(f.Price > 0));
   }
   ```

2. **Integration Tests (Full Conversations)**
   ```csharp
   [Fact]
   public async Task Agent_RemembersPastTrips()
   {
       var agent = CreateTestAgent();
       
    // Session 1: User mentions loving Tasmania
    await agent.SendAsync("I loved Tasmania! The Three Capes Track was incredible.");
       
    // Session 2: Agent should remember
       var response = await agent.SendAsync("Suggest a destination");
       
    Assert.Contains("Tasmania", response.Content);
   }
   ```

3. **Regression Tests (Prevent Old Bugs)**
   ```csharp
   [Fact]
   public async Task Agent_DoesNotExceedBudgetForBudgetTravelers()
   {
       // Bug #127: Agent recommended $5K trip to budget traveler
       
       var agent = CreateTestAgent(profile: "budget_traveler");
       var response = await agent.SendAsync("Plan a trip");
       
       var cost = ExtractCost(response);
       Assert.True(cost < 2500, "Exceeded budget traveler limit");
   }
   ```

**Key Concepts:**
- Test-driven agent development
- Conversation replay testing
- Edge case handling
- Test coverage metrics

---

## 📦 What You'll Have Built

By completing **Labs 0-7**, you'll have a production-ready travel agent that:

✅ **Lab 0:** Runs and responds to basic queries  
✅ **Lab 1:** Remembers user preferences with personalized memory
✅ **Lab 2:** Retrieves long-term conversation history with vector search
✅ **Lab 3:** Accesses real-time data with tools and extracts structured information
✅ **Lab 4:** Monitors performance and costs with observability
✅ **Lab 5:** Safely performs actions with approval workflows
✅ **Lab 6:** Coordinates specialist agents for complex planning
✅ **Lab 7:** Collects feedback for continuous improvement  

---

## 🎓 Learning Outcomes

After completing this workshop, you will understand:

1. **Personalization** - How agents adapt to user profiles and contexts
2. **Memory Architecture** - Short-term structured memory + long-term vector search
3. **Tool Design** - When and how to give agents real-world capabilities
4. **Observability** - Monitoring and debugging agents in production
5. **Safety Patterns** - Human-in-the-loop approval workflows
6. **Multi-Agent Systems** - Coordinating specialist agents for complex tasks
7. **Continuous Improvement** - Using feedback to make agents better

---

## 🚀 Getting Started

1. Navigate to `labs/00-setup/` to begin
2. Follow the README in each lab folder
3. Work in `starter/` folder, reference `completed/` when stuck
4. Run the agent after each lab to see your progress!

**Time Commitment:**
- **Labs 0-7:** 87 minutes (complete workshop)
- **Lab 0:** 5 min - Setup
- **Lab 1:** 15 min - Personalization & Memory
- **Lab 2:** 15 min - Vector Store
- **Lab 3:** 20 min - Tools & Structured Data
- **Lab 4:** 10 min - Observability
- **Lab 5:** 10 min - Human-in-the-Loop
- **Lab 6:** 12 min - Multi-Agent
- **Lab 7:** 10 min - Feedback

**Pro Tip:** After each lab, test the agent with your own travel planning scenarios to see how it improves!

---

## 📚 Additional Resources

- [Microsoft Agent Framework Documentation](https://aka.ms/agent-framework)
- [CopilotKit (AG-UI) Guide](https://docs.copilotkit.ai)
- [GitHub Models](https://github.com/marketplace/models)
- Workshop Documentation: `docs/` folder

---

## 🌟 Success Criteria

You'll know you've succeeded when you can have this conversation:

```
👤 "Plan my next vacation"

🤖 "Based on your profile (budget hiker who loved Tasmania's Three Capes Track), 
    I recommend Victoria's Great Ocean Road or New South Wales' Blue Mountains.
    
    [Checks weather] Perfect hiking weather in March!
    [Searches flights] Found flights for $1,250
    [Finds hotels] Great hostels for $60/night
    [Checks calendar] You're free March 8-20
    
    Total: $2,400 for 12 days. Want me to book it?"

👤 "Yes!"

🤖 [Creates approval workflow]
    "✅ Trip planned! Calendar updated. 
    Have an amazing adventure! 🌍"
```

**Ready to build your travel agent? Let's go! ✈️**
