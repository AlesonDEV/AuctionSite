import * as React from 'react';
import Box from "@mui/joy/Box";
import {WelcomeSection} from "@/features/home/sections/WelcomeSection";
import {AuctionsCorousel} from "@/features/home/sections/AuctionsCorousel";

export const HomePage = () => {
    return (
        <Box>
            <WelcomeSection />
            <AuctionsCorousel />
        </Box>
    );
};