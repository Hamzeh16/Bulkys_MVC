import { useState } from 'react';
import { FaBell } from 'react-icons/fa';

const NotificationsBell = ({ notifications = [] }) => {
  const [dropdownOpen, setDropdownOpen] = useState(false);

  return (
    <div className="relative">
      {/* Notification Bell Icon */}
      <div onClick={() => setDropdownOpen(!dropdownOpen)} className="cursor-pointer">
        <FaBell className="text-white text-2xl hover:text-gray-400 transition-colors duration-300" />
        {notifications.length > 0 && (
          <span className="absolute top-0 right-0 inline-flex items-center justify-center h-4 w-4 bg-red-600 text-white text-xs font-bold rounded-full">
            {notifications.length}
          </span>
        )}
      </div>

      {/* Notifications Dropdown */}
      {dropdownOpen && (
        <div className="absolute right-0 mt-2 w-64 bg-white shadow-md rounded-lg overflow-hidden z-50">
          {notifications.length > 0 ? (
            <ul>
              {notifications.map((notification, index) => (
                <li key={index} className="p-3 hover:bg-gray-200 cursor-pointer">
                  {notification}
                </li>
              ))}
            </ul>
          ) : (
            <div className="p-4 text-center text-gray-500">No new notifications</div>
          )}
        </div>
      )}
    </div>
  );
};

export default NotificationsBell;