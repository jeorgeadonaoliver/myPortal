export default function Footerbar() {
    return (

    <div className="flex flex-col-reverse justify-between pt-5 pb-10 border-t border-t-amber-700 lg:flex-row p-6">

            <p className="text-sm text-amber-50">
                © Copyright 2025 Apex Group Ltd. All rights reserved.
            </p>
        <ul className="flex flex-col mb-3 space-y-2 lg:mb-0 sm:space-y-0 sm:space-x-5 sm:flex-row">
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Privacy</a>
            </li>
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Cookie Notice</a>
            </li>
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Terms of Use</a>
            </li>
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Disclaimer</a>
            </li>
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Regulatory Status</a>
            </li>
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Anti Slavery</a>
            </li>
            <li>
                <a href="/" className="text-sm text-amber-50 transition-colors duration-300 hover:text-amber-700">Manage Cookies</a>
            </li>
        </ul>
  </div>

    );
}