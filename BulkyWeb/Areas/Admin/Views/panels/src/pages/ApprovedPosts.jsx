import React from 'react';

const ApprovedPosts = ({ posts, onStatusChange }) => {
  return (
    <div>
      <h1 className="text-2xl font-bold mb-4">Approved Posts</h1>
      <table className="min-w-full bg-white border border-gray-300">
        <thead>
          <tr>
            <th className="px-4 py-2 border-b">Job Title</th>
            <th className="px-4 py-2 border-b">Company Name</th>
            <th className="px-4 py-2 border-b">Posting Date</th>
            <th className="px-4 py-2 border-b">Type</th>
            <th className="px-4 py-2 border-b">Status</th>
            <th className="px-4 py-2 border-b">Actions</th>
          </tr>
        </thead>
        <tbody>
          {posts.map((post) => (
            <tr key={post.id} className="hover:bg-gray-100">
              <td className="px-4 py-2 border-b">{post.title}</td>
              <td className="px-4 py-2 border-b">{post.company}</td>
              <td className="px-4 py-2 border-b">{post.date}</td>
              <td className="px-4 py-2 border-b">{post.type}</td>
              <td className="px-4 py-2 border-b">{post.status}</td>
              <td className="px-4 py-2 border-b flex space-x-2">
                {/* أزرار تغيير الحالة */}
                <button 
                  className="bg-red-500 text-white px-4 py-2 rounded-full" 
                  onClick={() => onStatusChange(post.id, 'rejected')}
                >
                  Reject
                </button>
                <button 
                  className="bg-yellow-500 text-white px-4 py-2 rounded-full" 
                  onClick={() => onStatusChange(post.id, 'pending')}
                >
                  Pending
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ApprovedPosts;
