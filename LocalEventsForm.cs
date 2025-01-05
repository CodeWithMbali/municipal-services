using MetroFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MunicipalServicesApp
{
    public partial class LocalEventsForm : Form
    {
        SortedDictionary<DateTime, string> upcomingEvents = new SortedDictionary<DateTime, string>();
        Dictionary<string, Queue<string>> eventsByCategory = new Dictionary<string, Queue<string>>();
        Queue<string> recentSearches = new Queue<string>();
        SortedDictionary<DateTime, Queue<string>> highPriorityEvents = new SortedDictionary<DateTime, Queue<string>>();
        HashSet<string> uniqueEventNames = new HashSet<string>();

        public MetroColorStyle Style { get; internal set; }
        public MetroThemeStyle Theme { get; internal set; }

        public LocalEventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            // Adding dummy events
            AddEvent(new DateTime(2024, 10, 15), "Community Clean-up");
            AddEvent(new DateTime(2024, 11, 10), "Health Awareness Campaign");
            AddEvent(new DateTime(2024, 11, 10), "Health Awareness Campaign For Kids");
            AddEvent(new DateTime(2024, 12, 05), "Christmas Market");
            AddEvent(new DateTime(2024, 09, 25), "Local Art Exhibition");
            AddEvent(new DateTime(2024, 08, 30), "Youth Sports Day");
            AddEvent(new DateTime(2024, 10, 02), "Small Business Workshop");
            AddEvent(new DateTime(2024, 10, 31), "Halloween Parade");
            AddEvent(new DateTime(2024, 12, 24), "Holiday Food Drive");
            AddEvent(new DateTime(2025, 01, 15), "New Year's Community Picnic");

            // Adding categories
            AddEventByCategory("Community", "Community Clean-up");
            AddEventByCategory("Health", "Health Awareness Campaign");
            AddEventByCategory("Health", "Health Awareness Campaign For Kids");
            AddEventByCategory("Market", "Christmas Market");
            AddEventByCategory("Art", "Local Art Exhibition");
            AddEventByCategory("Sports", "Youth Sports Day");
            AddEventByCategory("Business", "Small Business Workshop");
            AddEventByCategory("Celebration", "Halloween Parade");
            AddEventByCategory("Charity", "Holiday Food Drive");
            AddEventByCategory("Community", "New Year's Community Picnic");

            // Adding high-priority events
            AddHighPriorityEvent("Emergency Town Hall Meeting", new DateTime(2024, 10, 01));
            AddHighPriorityEvent("Disaster Relief Fundraiser", new DateTime(2024, 11, 20));
            AddHighPriorityEvent("Flood Recovery Update", new DateTime(2024, 12, 10));

            DisplayEvents();
        }

        private void AddEvent(DateTime eventDate, string eventName)
        {
            if (!upcomingEvents.ContainsKey(eventDate))
            {
                uniqueEventNames.Add(eventName);
                upcomingEvents[eventDate] = eventName;
            }
        }

        private void AddEventByCategory(string category, string eventName)
        {
            if (!eventsByCategory.ContainsKey(category))
            {
                eventsByCategory[category] = new Queue<string>();
            }

            if (!eventsByCategory[category].Contains(eventName))
            {
                eventsByCategory[category].Enqueue(eventName);
            }
        }

        private void AddHighPriorityEvent(string eventName, DateTime eventDate)
        {
            if (!uniqueEventNames.Contains(eventName))
            {
                uniqueEventNames.Add(eventName);

                if (!highPriorityEvents.ContainsKey(eventDate))
                {
                    highPriorityEvents[eventDate] = new Queue<string>();
                }
                highPriorityEvents[eventDate].Enqueue(eventName);
            }
        }

        private void DisplayEvents()
        {
            lstEvents.Items.Clear();
            foreach (var eventItem in upcomingEvents)
            {
                lstEvents.Items.Add($"{eventItem.Key.ToShortDateString()}: {eventItem.Value}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstEvents.Items.Clear();
            string category = txtCategory.Text.Trim();
            DateTime searchDate;
            bool validDate = DateTime.TryParse(txtDate.Text, out searchDate);
            bool foundEvents = false;

            // Convert category to lowercase for case-insensitive comparison
            if (!string.IsNullOrEmpty(category))
            {
                // Find matching category ignoring case
                if (eventsByCategory.TryGetValue(category, out Queue<string> events))
                {
                    var matchingEvents = events.ToList();

                    if (validDate)
                    {
                        // Filter by both category and date
                        var filteredEvents = matchingEvents
                            .Where(evt => upcomingEvents.ContainsKey(searchDate) && upcomingEvents[searchDate] == evt)
                            .ToList();

                        if (filteredEvents.Any())
                        {
                            foreach (var evt in filteredEvents)
                                lstEvents.Items.Add($"{searchDate.ToShortDateString()}: {evt}");
                            foundEvents = true;
                        }
                    }
                    else
                    {
                        // Display all events in the category
                        foreach (var evt in matchingEvents)
                            lstEvents.Items.Add(evt);
                        foundEvents = true;
                    }
                }
            }
            else if (validDate && upcomingEvents.ContainsKey(searchDate))
            {
                // Filter by date only
                lstEvents.Items.Add($"{searchDate.ToShortDateString()}: {upcomingEvents[searchDate]}");
                foundEvents = true;
            }

            if (!foundEvents)
            {
                lstEvents.Items.Add("No events found for the specified category or date.");
            }

            // Update recent searches and recommendations
            if (!string.IsNullOrEmpty(category))
            {
                if (recentSearches.Count >= 5) recentSearches.Dequeue();
                recentSearches.Enqueue(category);
            }
            RecommendEvents();
        }

        private void RecommendEvents()
        {
            if (recentSearches.Count == 0)
            {
                lblRecommendations.Text = "No recommendations available.";
                return;
            }

            // Find categories related to recent searches
            var recommendedCategories = recentSearches
                .SelectMany(searchTerm => eventsByCategory
                    .Where(category => category.Key.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .Select(category => category.Key))
                .Distinct()
                .ToList();

            if (recommendedCategories.Any())
            {
                lblRecommendations.Text = $"You might be interested in events in these categories: {string.Join(", ", recommendedCategories)}";
            }
            else
            {
                lblRecommendations.Text = "No recommendations available.";
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e) { }

        private void LocalEventsForm_Load(object sender, EventArgs e) { }

        private void btnBackToSearch_Click(object sender, EventArgs e)
        {
            // Clear the search results
            lstEvents.Items.Clear();

            // Clear the search fields
            txtCategory.Text = "";
            txtDate.Text = "";

            lblRecommendations.Text = "Enter a category or date to search for events.";
        }
    }
}
