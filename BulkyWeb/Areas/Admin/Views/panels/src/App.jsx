import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import TopNavBar from './Components/TopNavBar';
import Sidebar from './Components/Sidebar';
import Dashboard from './pages/Dashboard';
import ApprovedPosts from './pages/ApprovedPosts';
import PendingApprovals from './pages/PendingApprovals';
import RejectedPosts from './pages/RejectedPosts';
import Analytics from './Components/Analytics';
import NotificationsBell from './Components/NotificationsBell';

import './index.css';

const LOCAL_STORAGE_KEY = 'jobPosts';

const App = () => {
  const [posts, setPosts] = useState([]);
  const [notifications, setNotifications] = useState([]);
  const [dropdownOpen, setDropdownOpen] = useState(false);

  // Restore data from localStorage on page load
  useEffect(() => {
    const storedPosts = JSON.parse(localStorage.getItem(LOCAL_STORAGE_KEY));
    if (storedPosts && storedPosts.length > 0) {
      setPosts(storedPosts);
    } else {
      // Default data if no stored data is available
      setPosts([
        { id: 1, title: "Software Engineer", company: "Tech Corp", date: "2024-01-12", type: "Job", status: "pending" },
        { id: 2, title: "Marketing Intern", company: "Biz Inc", date: "2024-01-15", type: "Internship", status: "pending" },
      ]);
    }
  }, []);

  // Update localStorage when posts change
  useEffect(() => {
    if (posts.length > 0) {
      localStorage.setItem(LOCAL_STORAGE_KEY, JSON.stringify(posts));
    }
    // Update notifications when posts change
    setNotifications(posts.filter(post => post.status === 'pending'));
  }, [posts]);

  // Function to change post status
  const handleStatusChange = (id, newStatus) => {
    const updatedPosts = posts.map(post =>
      post.id === id ? { ...post, status: newStatus } : post
    );
    setPosts(updatedPosts);
  };

  // Close the dropdown when clicking outside
  useEffect(() => {
    const handleClickOutside = (event) => {
      if (!event.target.closest('.notifications-dropdown') && !event.target.closest('.notification-bell')) {
        setDropdownOpen(false);
      }
    };
    document.addEventListener('mousedown', handleClickOutside);
    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
    };
  }, []);

  return (
    <Router>
      <div className="flex h-screen">
        <Sidebar />
        <div className="flex-1 flex flex-col">
          <TopNavBar />
          <div className="p-6 overflow-auto bg-gray-100">
            <div className="flex justify-end mb-4 relative">
              <NotificationsBell
                className="notification-bell"
                notifications={notifications}
                dropdownOpen={dropdownOpen}
                setDropdownOpen={setDropdownOpen}
              />
            </div>
            <Routes>
              <Route
                path="/"
                element={<Dashboard posts={posts} onStatusChange={handleStatusChange} />}
              />
              <Route
                path="/approved-posts"
                element={<ApprovedPosts posts={posts.filter(post => post.status === 'approved')} onStatusChange={handleStatusChange} />}
              />
              <Route
                path="/pending-approvals"
                element={<PendingApprovals posts={posts.filter(post => post.status === 'pending')} onStatusChange={handleStatusChange} />}
              />
              <Route
                path="/rejected-posts"
                element={<RejectedPosts posts={posts.filter(post => post.status === 'rejected')} onStatusChange={handleStatusChange} />}
              />
              <Route
                path="/analytics"
                element={<Analytics posts={posts} />}
              />
            </Routes>
          </div>
        </div>
      </div>
    </Router>
  );
};

export default App;